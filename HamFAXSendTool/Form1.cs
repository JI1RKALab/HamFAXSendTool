using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using net.sictransit.wefax;
using System.Numerics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace HamFAXSendTool
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// イメージパス
        /// </summary>
        string ImagePath = string.Empty;

        /// <summary>
        /// FAX停止信号パス
        /// </summary>
        string FAXStopSignalPath = string.Empty;

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
        /// イニシャライズ
        /// </summary>
        public Form1()
        {
            // OK
            InitializeComponent();
        }

        /// <summary>
        /// フォーム読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 読み込み
            new SettingClass().SettingFileLoad();

            // 停止信号作成
            FAXStopSignalPath = FAXStopSignalGenerator();
        }

        /// <summary>
        /// 画選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictSelectButton_Click(object sender, EventArgs e)
        {
            // ファイルOpen
            using (OpenFileDialog FileDialog = new())
            {
                // 設定
                FileDialog.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";
                FileDialog.FilterIndex = 0;
                FileDialog.RestoreDirectory = true;

                // 判定
                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 名前
                    ImagePath = FileDialog.FileName;
                }
                else
                {
                    // 名前がなければ処理出来ないので戻す
                    return;
                }
            }

            // 設定
            using (Image ImageData = Image.FromFile(ImagePath))
            {
                // ピクチャボックスに画像を表示
                SendPictureBox.Image = new Bitmap(ImagePath);

                // サイズモードをズームに設定
                SendPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (SendPictureBox.Image.Width > SendPictureBox.Image.Height)
                {
                    // 横長の場合はそれでOK
                    Console.WriteLine("OK");
                }
                else
                {
                    // 縦長の場合は調整する
                    SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
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
                WAVEBbutton.Enabled = true;
                SendButton.Enabled = true;
            }
        }

        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {
            // ボタン
            PictSelectButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            EndButton.Enabled = false;

            //SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

            //SerialPortControl.SerialPortControlOpen();

            //SerialPortControl.SerialPortControlClose();

            // 協動係数取得
            bool IOC288Flag = IOCComboBox.SelectedItem.ToString().Contains("288");

            // task
            Task.Run(() =>
            {
                // Status
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "FAX信号生成中..."));

                // 選択
                string FAXSignalPath = FAXSignalGenerator(IOC288Flag);

                // 再生部分の生成
                MainOutputStream = new WaveFileReader(FAXSignalPath);
                WaveChannel32 VolumeStream = new(MainOutputStream);

                // インスタンス生成
                FAXPlayer = new();

                // 初期化
                FAXPlayer.Init(VolumeStream);

                // 再生
                FAXPlayer.Play();

                // 停止ボタン
                StopButton.Invoke(new Action(() => StopButton.Enabled = true));

                // タイムスパン
                TimeSpan TimeSpanValue = new();

                // リメイン
                double RemainValue = 0;

                // 再生が終わる迄待機
                while (FAXPlayer.PlaybackState == PlaybackState.Playing)
                {
                    // 設定
                    TimeSpanValue = MainOutputStream.TotalTime - MainOutputStream.CurrentTime;
                    RemainValue = Math.Round(MainOutputStream.CurrentTime / MainOutputStream.TotalTime, 1);
                    DoingLabel.Invoke(new Action(() => DoingLabel.Text = RemainValue + "%送信中..." + Environment.NewLine + "残り:" + TimeSpanValue.Minutes + "分" + TimeSpanValue.Seconds + "秒"));
                }

                // 送信完了時は掃除
                MainOutputStream.Dispose();
                SendPictureBox.Image = null;
                ImagePath = string.Empty;

                // どちらにせよ、ファイルは消す
                if (string.IsNullOrWhiteSpace(FAXSignalPath))
                {
                    // OK
                    Console.WriteLine("OK");
                }
                else
                {
                    // 消す
                    File.Delete(FAXSignalPath);
                }

                // 停止判定
                if (ForceStop)
                {
                    // 再生が終わる迄待機
                    while (true)
                    {
                        // STOP
                        Thread.Sleep(1000);

                        // 判定
                        if (FAXPlayer.PlaybackState == PlaybackState.Playing)
                        {
                            // 抜け
                            break;
                        }
                        else
                        {
                            // 継続
                            continue;
                        }
                    }

                    // 再生が終わる迄待機
                    while (FAXPlayer.PlaybackState == PlaybackState.Playing)
                    {
                        // 判定
                        if (MainOutputStream.CurrentTime == MainOutputStream.TotalTime)
                        {
                            // 抜け
                            break;
                        }
                        else
                        {
                            // 継続
                            continue;
                        }
                    }

                    // 強制停止
                    ForceStop = false;
                    FAXPlayer.Stop();
                    FAXPlayer.Dispose();
                    MainOutputStream.Dispose();
                } else 
                {
                    // OK
                    Console.WriteLine("OK");
                }

                // 無効化
                PictSelectButton.Invoke(new Action(() => PictSelectButton.Enabled = true));
                EndButton.Invoke(new Action(() => EndButton.Enabled = false));
                WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = false));
                SendButton.Invoke(new Action(() => SendButton.Enabled = false));
                StopButton.Invoke(new Action(() => StopButton.Enabled = false));
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = string.Empty));
                IOCComboBox.Invoke(new Action(() => IOCComboBox.SelectedIndex = -1));
            });
        }

        /// <summary>
        /// 停止ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                // 停止信号を流す
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "停止信号強制送出中..."));

                // 再生部分の生成
                MainOutputStream = new WaveFileReader(FAXStopSignalPath);
                WaveChannel32 VolumeStream = new(MainOutputStream);

                // インスタンス生成
                FAXPlayer = new();

                // 初期化
                FAXPlayer.Init(VolumeStream);

                // 再生
                FAXPlayer.Play();

                // 送信完了時は掃除
                SendPictureBox.Invoke(new Action(() => SendPictureBox.Image = null));
                ImagePath = string.Empty;

                // どちらにせよ、ファイルは消す
                if (string.IsNullOrWhiteSpace(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav")))
                {
                    // OK
                    Console.WriteLine("OK");
                }
                else
                {
                    // 消す
                    if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav")))
                    {
                        // OK
                        File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav"));
                    }
                    else
                    {
                        // OK
                        Console.Write("OK");
                    }
                }
            });
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            // 閉じる
            this.Close();
        }

        /// <summary>
        /// 設定メニュー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingStripMenu_Click(object sender, EventArgs e)
        {
            // 設定ダイアログ表示
            new Form2().ShowDialog();
        }

        /// <summary>
        /// 緊急停止ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WAVEBbutton_Click(object sender, EventArgs e)
        {
            // ボタン無効化
            PictSelectButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            Task.Run(() => 
            {
                // OK
                DoingLabel.Invoke(new Action(()=> DoingLabel.Text = "FAX信号生成中..."));
            });

            // 選択
            string FAXSignalPath = FAXSignalGenerator(IOCComboBox.SelectedItem.ToString().Contains("288"));

            // 保存ダイヤログ
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog SignalSaveFileDialog = new();

            // はじめのファイル名を指定する
            // はじめに「ファイル名」で表示される文字列を指定する
            SignalSaveFileDialog.FileName = Path.GetFileName(FAXSignalPath);

            //// はじめに表示されるフォルダを指定する
            // sfd.InitialDirectory = @"C:\";

            // [ファイルの種類]に表示される選択肢を指定する
            // 指定しない（空の文字列）の時は、現在のディレクトリが表示される
            SignalSaveFileDialog.Filter = "WAVファイル(*.wav)|*.wav|すべてのファイル(*.*)|*.*";

            // [ファイルの種類]ではじめに選択されるものを指定する
            // 2番目の「すべてのファイル」が選択されているようにする
            SignalSaveFileDialog.FilterIndex = 0;

            // タイトルを設定する
            SignalSaveFileDialog.Title = "保存先のファイルを選択して下さい";

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            SignalSaveFileDialog.RestoreDirectory = true;

            // 既に存在するファイル名を指定したとき警告する
            // デフォルトでTrueなので指定する必要はない
            SignalSaveFileDialog.OverwritePrompt = true;

            // 存在しないパスが指定されたとき警告を表示する
            // デフォルトでTrueなので指定する必要はない
            SignalSaveFileDialog.CheckPathExists = true;

            // ダイアログ表示
            Task.Run(() =>
            {
                // OK
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "保存先選択中..."));
            });

            //ダイアログを表示する
            if (SignalSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(SignalSaveFileDialog.FileName);

                // OK
                Task.Run(() =>
                {
                    // OK
                    DoingLabel.Invoke(new Action(() => DoingLabel.Text = "保存処理中..."));
                });

                // コピー
                File.Copy(FAXSignalPath, SignalSaveFileDialog.FileName, true);

                // 送信完了時は掃除
                ImagePath = string.Empty;
                SendPictureBox.Image = null;

                // ボタン復活
                PictSelectButton.Enabled = false;
                WAVEBbutton.Enabled = false;
                SendButton.Enabled = false;
                IOCComboBox.SelectedIndex = -1;
            }
            else
            {
                // OK
                PictSelectButton.Enabled = true;
                WAVEBbutton.Enabled = true;
                SendButton.Enabled = true;
            }

            // OK
            Task.Run(() =>
            {
                // OK
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = string.Empty));
            });

            // どちらにせよ、ファイルは消す
            if (string.IsNullOrWhiteSpace(FAXSignalPath))
            {
                // OK
                Console.WriteLine("OK");
            }
            else
            {
                // 消す
                File.Delete(FAXSignalPath);
            }
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
                if (SendPictureBox.Image is null)
                {
                    // NG
                    return;
                }
                else
                {
                    // OK
                    WAVEBbutton.Enabled = true;
                    SendButton.Enabled = true;
                }
            }
        }

        /// <summary>
        /// FAX生成
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        private string FAXSignalGenerator(bool Is288Flag)
        {
            // ImageFilePath
            string TempImagePath = new ImageMake().MakeImage(ImagePath, Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            // WavePath
            string OutputFAXSignalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav");

            // IOC
            int IOCValue = Is288Flag ? 288 : 576;

            // FAX信号生成に投げ込む
            FaxMachine HamFaxMachine = new(16000, 1900, 400, IOCValue);

            // 信号生成
            HamFaxMachine.Fax(TempImagePath, OutputFAXSignalPath, new BinaryCodedHeader(null, null, null, null, null, null));

            // テンポラリファイル消す
            File.Delete(TempImagePath);

            // 戻し
            return OutputFAXSignalPath;
        }

        /// <summary>
        /// FAX停止信号生成
        /// </summary>
        /// <returns></returns>
        private string FAXStopSignalGenerator()
        {
            // ファイル生成
            string OutputFAXSignalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXStopSignal.wav");

            // 停止信号生成
            new FaxMachine().FAXStopSignalGenerator(OutputFAXSignalPath);

            // 戻し
            return OutputFAXSignalPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 判定
            if (string.IsNullOrWhiteSpace(FAXStopSignalPath))
            {
                // end
                return;
            }
            else
            {
                // 消し
                File.Delete(FAXStopSignalPath);

                // 消し
                FAXStopSignalPath = string.Empty;
            }
        }
    }
}