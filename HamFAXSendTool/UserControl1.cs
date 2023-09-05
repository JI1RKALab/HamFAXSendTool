using HamFAXSendTool.Properties;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace HamFAXSendTool
{
    public partial class UserControl1 : UserControl
    {
        /// <summary>
        /// FAX停止信号パス
        /// </summary>
        string FAXStopSignalPath = string.Empty;

        /// <summary>
        /// 回転角度
        /// </summary>
        int RotateValue = 0;

        /// <summary>
        /// 画像パスt
        /// </summary>
        string ImagePath = string.Empty;

        /// <summary>
        /// プレイヤー
        /// </summary>
        WaveOutEvent FAXPlayer = null;

        /// <summary>
        /// メインストリーム
        /// </summary>
        WaveStream MainOutputStream = null;

        /// <summary>
        /// 強制停止フラグ
        /// </summary>
        bool ForceStop = new();

        /// <summary>
        /// Add
        /// </summary>
        public UserControl1()
        {
            // Add
            InitializeComponent();
        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl1_Load(object sender, EventArgs e)
        {
            // IOC設定
            if (SettingClass.IOCSettingValue == new int())
            {
                // -1
                IOCComboBox.SelectedIndex = -1;
            }
            else
            {
                // 選択
                switch (SettingClass.IOCSettingValue)
                {
                    //IOC
                    case 288:
                        //1
                        IOCComboBox.SelectedIndex = 0;
                        break;
                    case 288576:
                        //2
                        IOCComboBox.SelectedIndex = 1;
                        break;
                    case 576:
                    default:
                        //3
                        IOCComboBox.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void PictSelectButton_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog PictFolderBrowserDialog = new FolderBrowserDialog
            {
                //上部に表示する説明テキストを指定する
                Description = "フォルダを指定して下さい...",
                //ルートフォルダを指定する
                //デフォルトでDesktop
                RootFolder = Environment.SpecialFolder.Desktop,
                //最初に選択するフォルダを指定する
                //RootFolder以下にあるフォルダである必要がある
                //SelectedPath = @"C:\Windows",
                //ユーザーが新しいフォルダを作成できるようにする
                //デフォルトでTrue
                ShowNewFolderButton = true
            };

            //ダイアログを表示する
            if (PictFolderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                DataSet dddd = new DataSet();

                // 中にある画像データを取り出してAddする          
                Directory.GetFiles(PictFolderBrowserDialog.SelectedPath,
                                                               "*", SearchOption.AllDirectories).
                                       Where(File => new string[]
                                       {
                                            ".jpg",
                                            ".JPG",
                                            ".gif" ,
                                            ".GIF",
                                            ".jpeg",
                                            ".JPEG",
                                            ".tiff",
                                            ".TIFF",
                                            ".PNG",
                                            ".png"
                                       }.
                                       Any(Pattern => File.ToLower().EndsWith(Pattern))).ToList().
                                       ForEach(x =>
                                       {
                                           PictCheckedListBox.Items.Add(x, true);
                                       });

                // 初期設定
                PictCheckedListBox.SelectedIndex = 0;

                // 設定
                using (Image ImageData = Image.FromFile(PictCheckedListBox.SelectedItem.ToString()))
                {
                    // Select
                    ImagePath = PictCheckedListBox.SelectedItem.ToString();

                    // ピクチャボックスに画像を表示
                    SendPictureBox.Image = new Bitmap(ImagePath);

                    // サイズモードをズームに設定
                    SendPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // OK
                    if (SendPictureBox.Image.Width > SendPictureBox.Image.Height)
                    {
                        // 横長の場合はそれでOK
                        RotateValue = 0;
                    }
                    else
                    {
                        // 縦長の場合は調整する
                        SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);

                        // 角度調整
                        RotateValue = 90;
                    }
                }

                // コンボが-1でない場合はボタン有効化
                if (IOCComboBox.SelectedIndex == -1)
                {
                    // NG
                    return;
                }
                else
                {
                    // OK
                    SendButton.Enabled = true;
                }
            }
            else
            {
                // return
                Console.WriteLine("return");
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            // フラグ
            ForceStop = true;

            // OK
            Task.Run(() =>
            {
                // 強制停止
                FAXPlayer.Stop();
                FAXPlayer.Dispose();
                MainOutputStream.Dispose();
                StopButton.Invoke(new Action(() => StopButton.Enabled = false));

                // 停止信号を流す
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "停止信号送出中..."));

                // 再生部分の生成
                MainOutputStream = new WaveFileReader(FAXStopSignalPath);
                WaveChannel32 VolumeStream = new(MainOutputStream);

                // インスタンス生成
                FAXPlayer = new();

                // 初期化
                FAXPlayer.DeviceNumber = PlaySoundCardIndexNoSelect();
                FAXPlayer.Init(VolumeStream);

                // 再生
                FAXPlayer.Play();

                // 送信完了時は掃除
                SendPictureBox.Invoke(new Action(() => SendPictureBox.Image = null));

                // どちらにせよ、ファイルは消す
                DeleteFAXFile();
            });
        }

        /// <summary>
        /// 協動係数コンボ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IOCComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 判定
            if (((ComboBox)sender).SelectedIndex == -1)
            {
                // NG
                return;
            }
            else
            {
                // Pict判定
                if (PictCheckedListBox.CheckedItems.Count > 0)
                {
                    // OK
                    SendButton.Enabled = true;
                }
                else
                {
                    // NG
                    return;
                }

                // 保存関数へ
                new SettingClass().IOCValueSave(((ComboBox)sender).SelectedText);
            }
        }


        /// <summary>
        /// ファイル消し
        /// </summary>
        private void DeleteFAXFile()
        {
            // 共通クラスに飛ばす
            new CommonProcessClass().DeleteFAXFile();
        }

        /// <summary>
        /// 再生デバイス取得
        /// </summary>
        /// <returns></returns>
        private int PlaySoundCardIndexNoSelect()
        {
            // 共通クラスへ
            return new CommonProcessClass().PlaySoundCardIndexNoSelect();
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
