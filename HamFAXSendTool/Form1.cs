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
                // �s�N�`���{�b�N�X�ɉ摜��\��
                SendPictureBox.Image = new Bitmap(imagePath);

                // �T�C�Y���[�h���Y�[���ɐݒ�
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

            // �C�j�V�����C�Y
            FaxMachine HamFaxMachine = new(16000, 1900, 400, 576);

            SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

            SerialPortControl.SerialPortControlOpen();

            SerialPortControl.SerialPortControlClose();


            // ���M�������͑|��
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
            // ����
            this.Close();
        }

        private void SettingStripMenu_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}