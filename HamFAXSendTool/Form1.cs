using net.sictransit.wefax;

namespace HamFAXSendTool
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// イメージパス
        /// </summary>
        string ImagePath = "";

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
        }

        /// <summary>
        /// 画選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictSelectButton_Click(object sender, EventArgs e)
        {

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

        private void SendButton_Click(object sender, EventArgs e)
        {
            PictSelectButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            StopButton.Enabled = true;

            // イニシャライズ
            FaxMachine HamFaxMachine = new(16000, 1900, 400, 576);

            SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

            SerialPortControl.SerialPortControlOpen();

            SerialPortControl.SerialPortControlClose();


            // 送信完了時は掃除
            SendPictureBox.Image = null; 
            ImagePath = string.Empty;

            // 無効化
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            StopButton.Enabled = false;
            StopButton.Enabled = false;
        }

        /// <summary>
        /// 停止ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            // 送信完了時は掃除
            SendPictureBox.Image = null;
            ImagePath = string.Empty;

            // ボタン無効化
            PictSelectButton.Enabled = true;
            WAVEBbutton.Enabled = true;
            SendButton.Enabled = true;
            StopButton.Enabled = false;
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


            // 送信完了時は掃除
            ImagePath = string.Empty;
            SendPictureBox.Image = null;

            // ボタン復活
            PictSelectButton.Enabled = true;
            WAVEBbutton.Enabled = true;
            SendButton.Enabled = true;
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
    }
}