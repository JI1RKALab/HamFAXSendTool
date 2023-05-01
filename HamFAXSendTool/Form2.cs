using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using System.IO;
using System.IO.Ports;

namespace HamFAXSendTool
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// イニシャライズ
        /// </summary>
        public Form2()
        {
            // 処理
            InitializeComponent();
        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            // サウンドカード取得
            List<NAudio.Wave.DirectSoundDeviceInfo> Capabilities = NAudio.Wave.DirectSoundOut.Devices.ToList();

            // ループ
            foreach (string CardName in Capabilities.Select(x => x.Description).ToList())
            {
                // Add
                SoundCardListBox.Items.Add(CardName);
            }
        }

        /// <summary>
        /// ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComTestButton_Click(object sender, EventArgs e)
        {
            // OK
            List<string> ErrorList = new();

            // Start
            if (ComPortListBox.SelectedIndex == -1)
            {
                // Comポート
                ErrorList.Add("・COMポート");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (ComVerListBox.SelectedIndex == -1)
            {
                // 通信方式
                ErrorList.Add("・COM通信方式");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (string.IsNullOrEmpty(BPSTextBox.Text))
            {
                // 通信方式
                ErrorList.Add("・通信速度入力");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }

            // はい
            if (ErrorList.Count > 0)
            {
                // エラー
                ErrorDisp(ErrorList);
            }
            else
            {
                // Error
            }
        }

        /// <summary>
        /// 未選択判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingButton_Click(object sender, EventArgs e)
        {
            // リスト
            List<string> ErrorList = new();

            // Start
            if (ComPortListBox.SelectedIndex == -1)
            {
                // Comポート
                ErrorList.Add("・COMポート");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (ComVerListBox.SelectedIndex == -1)
            {
                // 通信方式
                ErrorList.Add("・COM通信方式");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (string.IsNullOrEmpty(BPSTextBox.Text))
            {
                // 通信方式
                ErrorList.Add("・通信速度入力");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (SoundCardListBox.SelectedIndex == -1)
            {
                // サウンドカード
                ErrorList.Add("・出力サウンドカード");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }

            // はい
            if (ErrorList.Count > 0)
            {
                // エラー
                ErrorDisp(ErrorList);
            }
            else
            {
                // Error
            }
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="ErrorList"></param>
        private void ErrorDisp(List<string> ErrorList)
        {
            // エラー
            MessageBox.Show("下記設定エラーが出ています" + Environment.NewLine
                                    + "ご確認下さい" + Environment.NewLine
                                    + string.Join(Environment.NewLine, ErrorList),
                                    "設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // OK
            this.Close();
        }

        /// <summary>
        /// BPS入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPSTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // バックスペースが押された時は有効（Deleteキーも有効）
            if (e.KeyChar == '\b')
            {
                // OK
                return;
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }

            // 数値0～9以外が押された時はイベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                // OK
                e.Handled = true;
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
        }
    }
}