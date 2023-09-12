using NAudio.Wave;
using net.sictransit.wefax;
using System.Data;
using System.Reflection;

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
            // 停止信号作成
            FAXStopSignalPath = FAXStopSignalGenerator();

            // RPM設定
            if (SettingClass.RPMSettingValue == new int())
            {
                // -1
                RPMSelectComboBox.SelectedIndex = -1;
            }
            else
            {  // 選択
                switch (SettingClass.RPMSettingValue)
                {
                    // 選択
                    case 60:
                        // 1
                        RPMSelectComboBox.SelectedIndex = 0;
                        break;
                    case 120:
                        // 1
                        RPMSelectComboBox.SelectedIndex = 1;
                        break;
                    case 240:
                        // 1
                        RPMSelectComboBox.SelectedIndex = 2;
                        break;
                    case 360:
                        // 1
                        RPMSelectComboBox.SelectedIndex = 3;
                        break;
                }
            }

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

            // OK
            SendButton.Enabled = false;
        }

        /// <summary>
        /// 画像選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                                           PictCheckedListBox.Items.Add(x, false);
                                       });

                // 初期設定
                PictCheckedListBox.SelectedIndex = 0;

                // 設定
                SetPictBox(PictCheckedListBox.SelectedItem.ToString());

                // コンボが-1でない場合はボタン有効化
                if (IOCComboBox.SelectedIndex == -1 || RPMSelectComboBox.SelectedIndex == -1)
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

        /// <summary>
        /// イメージ投射
        /// </summary>
        /// <param name="PictImagePath"></param>
        private void SetPictBox(string PictImagePath)
        {
            // 設定
            using (Image ImageData = Image.FromFile(PictImagePath))
            {
                // Select
                ImagePath = PictImagePath;

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
        }

        /// <summary>
        /// 送信ボタンクリック
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
            ForceStop = false;
            PictSelectButton.Enabled = false;
            //PictRotateButton.Enabled = false;
            //WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            EndButton.Enabled = false;

            // RPMValue
            int RPMVlaue = RPMConboBoxGetSelectItem();

            // ICOValue
            int IOCValue = IOCConboBoxGetSelectItem();

            // task
            _ = Task.Run(() =>
            {
                // errorfalse
                bool IsErrorFlag = new();

                // ループ
                while (!ForceStop)
                {
                    // ループ
                    for (int i = 0; i < PictCheckedListBox.Items.Count; i++)
                    {
                        // 判定
                        if (PictCheckedListBox.GetItemChecked(i))
                        {
                            // Cue
                            IsErrorFlag = new();

                            // Status
                            DoingLabel.Invoke(new Action(() => DoingLabel.Text = "FAX信号生成中..."));

                            // シリアルポート
                            SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

                            // pict
                            PictCheckedListBox.Invoke(new Action(() => PictCheckedListBox.SelectedIndex = i));
                            PictCheckedListBox.Invoke(new Action(() => SetPictBox(PictCheckedListBox.SelectedItem.ToString())));

                            // トライキャッチ
                            try
                            {
                                // 選択
                                string FAXSignalPath = FAXSignalGenerator(RPMVlaue, IOCValue);

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
                                SendPictureBox.Invoke(new Action(() => SendPictureBox.Image = null));

                                // どちらにせよ、ファイルは消す
                                if (string.IsNullOrWhiteSpace(FAXSignalPath))
                                {
                                    // OK
                                    Console.WriteLine("OK");
                                }
                                else
                                {
                                    // 消す
                                    System.IO.File.Delete(FAXSignalPath);
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
                        }
                        else
                        {
                            // OK
                            StopButton.Invoke(new Action(() => StopButton.Enabled = true));

                            // 次
                            continue;
                        }
                    }
                }

                //// 判定
                //if (IsErrorFlag)
                //{
                //    // 有効化
                //    //WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = true));
                //    SendButton.Invoke(new Action(() => SendButton.Enabled = true));
                //}
                //else
                //{
                //    // 無効化
                //    //WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = false));
                //    SendButton.Invoke(new Action(() => SendButton.Enabled = false));
                //}

                //// 共通
                //PictSelectButton.Invoke(new Action(() => PictSelectButton.Enabled = true));
                //EndButton.Invoke(new Action(() => EndButton.Enabled = true));
                //StopButton.Invoke(new Action(() => StopButton.Enabled = false));
                //DoingLabel.Invoke(new Action(() => DoingLabel.Text = string.Empty));
            });
        }

        /// <summary>
        /// FAX生成
        /// </summary>
        /// <param name="RPMValue"></param>
        /// <param name="IOCValue"></param>
        /// <returns></returns>
        private string FAXSignalGenerator(int RPMValue, int IOCValue)
        {
            // PictBoxに出ている画像を保存する
            string SendImagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "SendImage.png");

            // 一時保存
            SendPictureBox.Invoke(new Action(() => SendPictureBox.Image.Save(SendImagePath, System.Drawing.Imaging.ImageFormat.Png)));

            // ImageFilePath
            string TempImagePath = new ImageMake().MakeImage(SendImagePath, Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            // WavePath
            string OutputFAXSignalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav");

            // FAX信号生成に投げ込む
            FaxMachine HamFaxMachine = new(16000, 1900, 400, IOCValue);

            // 信号生成
            HamFaxMachine.Fax(TempImagePath, OutputFAXSignalPath, RPMValue, new BinaryCodedHeader(null, null, null, null, null, null));

            // テンポラリファイル消す
            File.Delete(TempImagePath);
            File.Delete(SendImagePath);

            // 戻し
            return OutputFAXSignalPath;
        }

        /// <summary>
        /// 協動係数選択
        /// </summary>
        /// <returns></returns>
        private int IOCConboBoxGetSelectItem()
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
        /// 回転数
        /// </summary>
        /// <returns></returns>
        private int RPMConboBoxGetSelectItem()
        {
            // 設定
            if (RPMSelectComboBox.SelectedIndex == -1)
            {
                // 未選択の場合は120
                return 120;
            }
            else
            {
                // それ以外は選択された値
                return int.Parse(RPMSelectComboBox.SelectedItem.ToString().Replace("回転", string.Empty));
            }
        }

        /// <summary>
        /// 停止処理
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
                // 待機
                bool WaitFlag = new();

                // OK
                if (FAXPlayer is null)
                {
                    // OK
                    WaitFlag = true;
                    Console.WriteLine("OK");
                }
                else
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
                    FAXPlayer = new()
                    {
                        // 選択
                        DeviceNumber = PlaySoundCardIndexNoSelect()
                    };

                    // 初期化
                    FAXPlayer.Init(VolumeStream);

                    // 再生
                    FAXPlayer.Play();

                    // 送信完了時は掃除
                    SendPictureBox.Invoke(new Action(() => SendPictureBox.Image = null));

                    // どちらにせよ、ファイルは消す
                    DeleteFAXFile();

                    // 待機
                    while (FAXPlayer.PlaybackState == PlaybackState.Playing)
                    {
                        // OK
                        Console.WriteLine("OK");
                    }

                    // OK
                    WaitFlag = true;
                }

                // Wait
                while (!WaitFlag)
                {
                    // OK
                    Console.WriteLine("OK");
                }

                // 有効化
                //WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = true));
                SendButton.Invoke(new Action(() => SendButton.Enabled = true));
                PictSelectButton.Invoke(new Action(() => PictSelectButton.Enabled = true));
                EndButton.Invoke(new Action(() => EndButton.Enabled = true));
                StopButton.Invoke(new Action(() => StopButton.Enabled = false));
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = string.Empty));
            });
        }

        /// <summary>
        /// FAX停止信号生成
        /// </summary>
        /// <returns></returns>
        private string FAXStopSignalGenerator()
        {
            // 戻し
            return new CommonProcessClass().FAXStopSignalGenerator(RPMConboBoxGetSelectItem());
        }

        /// <summary>
        /// 回転数コンボ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPMSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 判定
            if (((ComboBox)sender).SelectedIndex == -1)
            {
                // NG
                return;
            }
            else
            {
                // 保存関数へ
                new SettingClass().RPMValueSave(((ComboBox)sender).SelectedItem.ToString().Replace("回転", string.Empty));

                // Pict判定
                if (PictCheckedListBox.CheckedItems.Count > 0 || IOCComboBox.SelectedIndex >= 0)
                {
                    // OK
                    SendButton.Enabled = true;
                }
                else
                {
                    // NG
                    return;
                }
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
                // 保存関数へ
                new SettingClass().IOCValueSave(((ComboBox)sender).SelectedText);

                // Pict判定
                if (PictCheckedListBox.CheckedItems.Count > 0 || RPMSelectComboBox.SelectedIndex >= 0)
                {
                    // OK
                    SendButton.Enabled = true;
                }
                else
                {
                    // NG
                    return;
                }
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
        /// 実施
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 選択
            if (e.NewValue == CheckState.Unchecked)
            {
                // 実施
                return;
            }
            else
            {
                // 送信
                SetPictBox(((CheckedListBox)sender).SelectedItem.ToString());
            }
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            // quit
            Application.Exit();
        }
    }
}