using net.sictransit.wefax;

namespace HamFAXSendTool
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// �C���[�W�p�X
        /// </summary>
        string ImagePath = "";

        /// <summary>
        /// �C�j�V�����C�Y
        /// </summary>
        public Form1()
        {
            // OK
            InitializeComponent();
        }

        /// <summary>
        /// �t�H�[���ǂݍ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // �ǂݍ���
            new SettingClass().SettingFileLoad();
        }

        /// <summary>
        /// ��I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictSelectButton_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog FileDialog = new())
            {
                // �ݒ�
                FileDialog.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";
                FileDialog.FilterIndex = 0;
                FileDialog.RestoreDirectory = true;

                // ����
                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ���O
                    ImagePath = FileDialog.FileName;
                }
                else
                {
                    // ���O���Ȃ���Ώ����o���Ȃ��̂Ŗ߂�
                    return;
                }
            }

            // �ݒ�
            using (Image ImageData = Image.FromFile(ImagePath))
            {
                // �s�N�`���{�b�N�X�ɉ摜��\��
                SendPictureBox.Image = new Bitmap(ImagePath);

                // �T�C�Y���[�h���Y�[���ɐݒ�
                SendPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                if (SendPictureBox.Image.Width > SendPictureBox.Image.Height)
                {
                    // �����̏ꍇ�͂����OK
                    Console.WriteLine("OK");
                }
                else
                {
                    // �c���̏ꍇ�͒�������
                    SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                }
            }

            // �R���{��-1�łȂ��ꍇ�̓{�^���L����
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

            // �C�j�V�����C�Y
            FaxMachine HamFaxMachine = new(16000, 1900, 400, 576);

            SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

            SerialPortControl.SerialPortControlOpen();

            SerialPortControl.SerialPortControlClose();


            // ���M�������͑|��
            SendPictureBox.Image = null; 
            ImagePath = string.Empty;

            // ������
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            StopButton.Enabled = false;
            StopButton.Enabled = false;
        }

        /// <summary>
        /// ��~�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            // ���M�������͑|��
            SendPictureBox.Image = null;
            ImagePath = string.Empty;

            // �{�^��������
            PictSelectButton.Enabled = true;
            WAVEBbutton.Enabled = true;
            SendButton.Enabled = true;
            StopButton.Enabled = false;
        }

        /// <summary>
        /// �I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            // ����
            this.Close();
        }

        /// <summary>
        /// �ݒ胁�j���[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingStripMenu_Click(object sender, EventArgs e)
        {
            // �ݒ�_�C�A���O�\��
            new Form2().ShowDialog();
        }

        /// <summary>
        /// �ً}��~�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WAVEBbutton_Click(object sender, EventArgs e)
        {
            // �{�^��������
            PictSelectButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;


            // ���M�������͑|��
            ImagePath = string.Empty;
            SendPictureBox.Image = null;

            // �{�^������
            PictSelectButton.Enabled = true;
            WAVEBbutton.Enabled = true;
            SendButton.Enabled = true;
        }

        /// <summary>
        /// �����W���R���{
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IOCComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ����
            if (((ComboBox)sender).SelectedIndex == -1)
            {
                // NG
                return;
            }
            else 
            {
                // Pict����
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