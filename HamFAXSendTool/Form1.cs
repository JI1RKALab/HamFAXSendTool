using HamFAXSendTool.Properties;
using NAudio.Wave;
using net.sictransit.wefax;
using System.Diagnostics;
using System.Reflection;
using Image = System.Drawing.Image;

namespace HamFAXSendTool
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// FAX停止信号パス
        /// </summary>
        string FAXStopSignalPath = string.Empty;

        /// <summary>
        /// ファイル名
        /// </summary>
        const string SoftName = "アマチュア無線FAX送信ツール";

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
        /// 回転角度
        /// </summary>
        int RotateValue = 0;

        /// <summary>
        /// 画像パスt
        /// </summary>
        string ImagePath = string.Empty;

        /// <summary>
        /// 展示会モード
        /// </summary>
        bool DispMode = new bool();

        /// <summary>
        /// イニシャライズ
        /// </summary>
        public Form1(string[] args)
        {
            // OK
            InitializeComponent();

            // 判定
            if (args.Count() > 0) 
            {
                // 判定
                if (args.FirstOrDefault() == "TESTMODE") 
                { 
                    // OK
                    DispMode = true; 
                } 
                else
                { 
                    // NG
                    DispMode = false;
                }
            }
            else 
            {
                // NG
                DispMode = false;
            }
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

            // コールサイン未設定?
            if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
            {
                // メッセージ
                MessageBox.Show("現在コールサイン未登録です" + Environment.NewLine + "コールサインの登録をお願いします", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // フォーム3
                new Form3().ShowDialog();

                // 設定
                if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
                {
                    // それでも尚未設定
                    Text = SoftName + "(コールサイン:未設定!)";
                }
                else
                {
                    // 設定済み
                    Text = SoftName + "(コールサイン:" + SettingClass.UserCallSign + ")";
                }
            }
            else
            {
                // 設定済み
                Text = SoftName + "(コールサイン:" + SettingClass.UserCallSign + ")";
            }

            // こっから展示会モード
            if (DispMode)
            {
                // 展示会モードの時は既存の画面を消す
                StatusTitleLable.Visible = false;
                DoingLabel.Visible = false; 
                SendLabel.Visible = false;
                IOCComboBox.Visible = false;
                IOCTitleLable.Visible = false;
                IOCTitleLable.Visible = false;
                PictSelectButton.Visible = false;
                PictRotateButton.Visible = false;
                WAVEBbutton.Visible = false;
                SendButton.Visible = false;
                EndButton.Visible = false;
                StopButton.Visible = false;
                SendPictureBox.Visible = false;

                // テストモードを出す
                this.Controls.Add(new UserControl1
                {
                    // ロケ指定
                    Location = new Point(0, 30)
                });

                // ヘッダも書き換える
                this.Text = SoftName + "(展示会モード)";
            }
            else
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

            // 画像回転ボタンを有効にする
            PictRotateButton.Enabled = true;

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
        /// 画像回転
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictRotateButton_Click(object sender, EventArgs e)
        {
            // 設定
            using (Image ImageData = Image.FromFile(ImagePath))
            {
                // ピクチャボックスに画像を表示
                SendPictureBox.Image = new Bitmap(ImagePath);

                // サイズモードをズームに設定
                SendPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                // 回転
                if (RotateValue == 0)
                {
                    // 90
                    SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    RotateValue = 90;
                }
                else if (RotateValue == 90)
                {
                    // 180
                    SendPictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    RotateValue = 180;
                }
                else if (RotateValue == 180)
                {
                    // 270
                    SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    RotateValue = 270;
                }
                else if (RotateValue == 270)
                {
                    // 0
                    SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipXY);
                    RotateValue = 0;
                }
                else
                {
                    // OK
                    Console.WriteLine("OK");
                }
            }
        }

        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {
            // OK
            List<string> ErrorList = new();

            // Start
            if (string.IsNullOrWhiteSpace(SettingClass.ComPort))
            {
                // Comポート
                ErrorList.Add("・COMポート");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (string.IsNullOrWhiteSpace(SettingClass.ComSet))
            {
                // 通信方式
                ErrorList.Add("・COM通信方式");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (0 >= SettingClass.ComSpeed)
            {
                // 通信方式
                ErrorList.Add("・通信速度入力");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (string.IsNullOrWhiteSpace(SettingClass.SoundCard))
            {
                // サウンドカード
                ErrorList.Add("・出力サウンドカード");
            }
            else
            {
                // ある?
                if (DirectSoundOut.Devices.Select(x => x.Description == SettingClass.SoundCard).ToList().Count == 0)
                {
                    // ERROR
                    ErrorList.Add("・設定済みサウンドカード無効");
                }
                else
                {
                    // OK
                    Console.WriteLine("OK");
                }
            }
            if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
            {
                // サウンドカード
                ErrorList.Add("・コールサイン");
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
                MessageBox.Show("下記設定エラーが出ています" + Environment.NewLine
                                        + "ご確認下さい" + Environment.NewLine
                                        + string.Join(Environment.NewLine, ErrorList),
                                        "設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // コールサイン設定する?
                if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
                {
                    // 判定
                    if (MessageBox.Show("コールサイン設定後送信可能になります"
                                        + Environment.NewLine + "設定しますか?",
                                        "コールサイン設定確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // 表示
                        new Form3().ShowDialog();

                        // ヘッダ書き換え
                        Name = SoftName + "(コールサイン:" + SettingClass.UserCallSign + ")";

                        // 送信
                        FAXSend();
                    }
                    else
                    {
                        // 送信出来ない
                        return;
                    }
                }
                else
                {
                    // 送信出来ない
                    return;
                }
            }
            else
            {
                // 送信
                FAXSend();
            }
        }

        /// <summary>
        /// FAX送信
        /// </summary>
        private void FAXSend()
        {
            // ボタン
            PictSelectButton.Enabled = false;
            PictRotateButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            EndButton.Enabled = false;

            // ICOValue
            int IOCValue = ICOConboBoxGetSelectItem();

            // task
            Task.Run(() =>
            {
                // errorfalse
                bool IsErrorFlag = new();

                // Status
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "FAX信号生成中..."));

                // シリアルポート
                SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

                // トライキャッチ
                try
                {
                    // 選択
                    string FAXSignalPath = FAXSignalGenerator(IOCValue);

                    // 再生部分の生成
                    MainOutputStream = new WaveFileReader(FAXSignalPath);
                    WaveChannel32 VolumeStream = new(MainOutputStream);

                    // インスタンス生成
                    FAXPlayer = new();

                    // 初期化
                    FAXPlayer.DeviceNumber = PlaySoundCardIndexNoSelect();
                    FAXPlayer.Init(VolumeStream);

                    // COM設定?
                    if (SettingClass.ComPort.Contains("COM"))
                    {
                        // スタート
                        SerialPortControl.SerialPortControlOpen();
                    }
                    else
                    {
                        // NG
                        Console.WriteLine("NG");
                    }

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
                        RemainValue = Math.Round(MainOutputStream.CurrentTime / MainOutputStream.TotalTime * 100);
                        DoingLabel.Invoke(new Action(() => DoingLabel.Text = RemainValue + "%送信中..." + Environment.NewLine + "残り:" + TimeSpanValue.Minutes + "分" + TimeSpanValue.Seconds + "秒"));

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

                    // 送信完了時は掃除
                    MainOutputStream.Dispose();
                    SendPictureBox.Image = null;

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
                    }
                    else
                    {
                        // OK
                        FAXPlayer.Stop();
                        FAXPlayer.Dispose();
                        MainOutputStream.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    // ERror
                    MessageBox.Show("ソフトが停止しました" + Environment.NewLine + "理由は下記の通りです" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // 終了
                    if (FAXPlayer is null)
                    {
                        // OK
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        // 停止
                        FAXPlayer.Stop();
                        FAXPlayer.Dispose();
                    }

                    // 終了
                    if (MainOutputStream is null)
                    {
                        // OK
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        // 捨て
                        MainOutputStream.Dispose();
                    }

                    // ERRor
                    IsErrorFlag = true;

                    // どちらにせよ、ファイルは消す
                    DeleteFAXFile();
                }

                // チェック
                if (SerialPortControl.SerialPort.IsOpen)
                {
                    // 閉じる
                    SerialPortControl.SerialPortControlClose();
                }
                else
                {
                    // OK
                    Console.WriteLine("OK");
                }

                // 判定
                if (IsErrorFlag)
                {
                    // 有効化
                    WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = true));
                    SendButton.Invoke(new Action(() => SendButton.Enabled = true));
                }
                else
                {
                    // 無効化
                    WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = false));
                    SendButton.Invoke(new Action(() => SendButton.Enabled = false));
                }

                // 共通
                PictSelectButton.Invoke(new Action(() => PictSelectButton.Enabled = true));
                EndButton.Invoke(new Action(() => EndButton.Enabled = true));
                StopButton.Invoke(new Action(() => StopButton.Enabled = false));
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = string.Empty));
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

            // 設定済み
            Text = SoftName + "(コールサイン:" + SettingClass.UserCallSign + ")";
        }

        /// <summary>
        /// 協動係数選択
        /// </summary>
        /// <returns></returns>
        private int ICOConboBoxGetSelectItem()
        {
            // 選択
            switch (IOCComboBox.SelectedItem.ToString())
            {
                // HAM1
                case "288(アマチュア無線モード1)":
                    return 288;

                // HAM2
                case "288/576(アマチュア無線モード2)":
                    return 288576;

                // OK
                case "576(業務局モード)":
                default:
                    return 576;
            }
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
            PictRotateButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            EndButton.Enabled = false;
            Task.Run(() =>
            {
                // OK
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "FAX信号生成中..."));
            });

            // 選択
            string FAXSignalPath = FAXSignalGenerator(ICOConboBoxGetSelectItem());

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
                SendPictureBox.Image = null;

                // ボタン復活
                PictSelectButton.Enabled = true;
                WAVEBbutton.Enabled = false;
                SendButton.Enabled = false;
                EndButton.Enabled = true;
                IOCComboBox.SelectedIndex = -1;
            }
            else
            {
                // OK
                PictSelectButton.Enabled = true;
                PictRotateButton.Enabled = true;
                WAVEBbutton.Enabled = true;
                SendButton.Enabled = true;
                EndButton.Enabled = true;
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

                // 保存関数へ
                new SettingClass().IOCValueSave(((ComboBox)sender).SelectedText);
            }
        }

        /// <summary>
        /// FAX生成
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        private string FAXSignalGenerator(int IOCValue)
        {
            // PictBoxに出ている画像を保存する
            string SendImagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "SendImage.png");

            // 一時保存
            SendPictureBox.Image.Save(SendImagePath, System.Drawing.Imaging.ImageFormat.Png);

            // ImageFilePath
            string TempImagePath = new ImageMake().MakeImage(SendImagePath, Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            // WavePath
            string OutputFAXSignalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav");

            // FAX信号生成に投げ込む
            FaxMachine HamFaxMachine = new(16000, 1900, 400, IOCValue);

            // 信号生成
            HamFaxMachine.Fax(TempImagePath, OutputFAXSignalPath, new BinaryCodedHeader(null, null, null, null, null, null));

            // テンポラリファイル消す
            File.Delete(TempImagePath);
            File.Delete(SendImagePath);

            // 戻し
            return OutputFAXSignalPath;
        }

        /// <summary>
        /// FAX停止信号生成
        /// </summary>
        /// <returns></returns>
        private string FAXStopSignalGenerator()
        {
            // 戻し
            return new CommonProcessClass().FAXStopSignalGenerator();
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

        /// <summary>
        /// オンラインヘルプ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispOnLineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // URL
            Process.Start(new ProcessStartInfo()
            {
                FileName = "http://ji1rka.radio/fax-manual.pdf",
                UseShellExecute = true,
            });
        }
    }
}