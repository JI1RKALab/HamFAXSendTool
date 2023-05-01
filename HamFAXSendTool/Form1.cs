using net.sictransit.wefax;

namespace HamFAXSendTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new SettingClass().SettingFileLoad();
        }

        private void PictSelectButton_Click(object sender, EventArgs e)
        {
            string imagePath = @"";

            using (Image ImageData = Image.FromFile(imagePath))
            {
                // ピクチャボックスに画像を表示
                SendPictureBox.Image = new Bitmap(imagePath);

                // サイズモードをズームに設定
                SendPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipXY);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            PictSelectButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            StopButton.Enabled = true;
            StopButton.Enabled = false;

            // イニシャライズ
            FaxMachine HamFaxMachine = new(16000, 1900, 400, 576);

            SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

            SerialPortControl.SerialPortControlOpen();

            SerialPortControl.SerialPortControlClose();


            // 送信完了時は掃除
            SendPictureBox.Image = null;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            PictSelectButton.Enabled = true;
            WAVEBbutton.Enabled = true;
            SendButton.Enabled = true;
            StopButton.Enabled = false;
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            // 閉じる
            this.Close();
        }

        private void SettingStripMenu_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}