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
        /// FAX��~�M���p�X
        /// </summary>
        string FAXStopSignalPath = string.Empty;

        /// <summary>
        /// �t�@�C����
        /// </summary>
        const string SoftName = "�A�}�`���A����FAX���M�c�[��";

        /// <summary>
        /// �v���C���[
        /// </summary>
        WaveOutEvent FAXPlayer = null;

        /// <summary>
        /// ���C���X�g���[��
        /// </summary>
        WaveStream MainOutputStream = null;

        /// <summary>
        /// ������~�t���O
        /// </summary>
        bool ForceStop = new();

        /// <summary>
        /// ��]�p�x
        /// </summary>
        int RotateValue = 0;

        /// <summary>
        /// �摜�p�Xt
        /// </summary>
        string ImagePath = string.Empty;

        /// <summary>
        /// �W����[�h
        /// </summary>
        bool DispMode = new bool();

        /// <summary>
        /// �C�j�V�����C�Y
        /// </summary>
        public Form1(string[] args)
        {
            // OK
            InitializeComponent();

            // ����
            if (args.Count() > 0) 
            {
                // ����
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
        /// �t�H�[���ǂݍ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // �ǂݍ���
            new SettingClass().SettingFileLoad();

            // ��~�M���쐬
            FAXStopSignalPath = FAXStopSignalGenerator();

            // �R�[���T�C�����ݒ�?
            if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
            {
                // ���b�Z�[�W
                MessageBox.Show("���݃R�[���T�C�����o�^�ł�" + Environment.NewLine + "�R�[���T�C���̓o�^�����肢���܂�", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // �t�H�[��3
                new Form3().ShowDialog();

                // �ݒ�
                if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
                {
                    // ����ł������ݒ�
                    Text = SoftName + "(�R�[���T�C��:���ݒ�!)";
                }
                else
                {
                    // �ݒ�ς�
                    Text = SoftName + "(�R�[���T�C��:" + SettingClass.UserCallSign + ")";
                }
            }
            else
            {
                // �ݒ�ς�
                Text = SoftName + "(�R�[���T�C��:" + SettingClass.UserCallSign + ")";
            }

            // ��������W����[�h
            if (DispMode)
            {
                // �W����[�h�̎��͊����̉�ʂ�����
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

                // �e�X�g���[�h���o��
                this.Controls.Add(new UserControl1
                {
                    // ���P�w��
                    Location = new Point(0, 30)
                });

                // �w�b�_������������
                this.Text = SoftName + "(�W����[�h)";
            }
            else
            {
                // IOC�ݒ�
                if (SettingClass.IOCSettingValue == new int())
                {
                    // -1
                    IOCComboBox.SelectedIndex = -1;
                }
                else
                {
                    // �I��
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
        /// ��I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictSelectButton_Click(object sender, EventArgs e)
        {
            // �t�@�C��Open
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

                // OK
                if (SendPictureBox.Image.Width > SendPictureBox.Image.Height)
                {
                    // �����̏ꍇ�͂����OK
                    RotateValue = 0;
                }
                else
                {
                    // �c���̏ꍇ�͒�������
                    SendPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);

                    // �p�x����
                    RotateValue = 90;
                }
            }

            // �摜��]�{�^����L���ɂ���
            PictRotateButton.Enabled = true;

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

        /// <summary>
        /// �摜��]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictRotateButton_Click(object sender, EventArgs e)
        {
            // �ݒ�
            using (Image ImageData = Image.FromFile(ImagePath))
            {
                // �s�N�`���{�b�N�X�ɉ摜��\��
                SendPictureBox.Image = new Bitmap(ImagePath);

                // �T�C�Y���[�h���Y�[���ɐݒ�
                SendPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                // ��]
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
        /// ���M
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
                // Com�|�[�g
                ErrorList.Add("�ECOM�|�[�g");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (string.IsNullOrWhiteSpace(SettingClass.ComSet))
            {
                // �ʐM����
                ErrorList.Add("�ECOM�ʐM����");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (0 >= SettingClass.ComSpeed)
            {
                // �ʐM����
                ErrorList.Add("�E�ʐM���x����");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }
            if (string.IsNullOrWhiteSpace(SettingClass.SoundCard))
            {
                // �T�E���h�J�[�h
                ErrorList.Add("�E�o�̓T�E���h�J�[�h");
            }
            else
            {
                // ����?
                if (DirectSoundOut.Devices.Select(x => x.Description == SettingClass.SoundCard).ToList().Count == 0)
                {
                    // ERROR
                    ErrorList.Add("�E�ݒ�ς݃T�E���h�J�[�h����");
                }
                else
                {
                    // OK
                    Console.WriteLine("OK");
                }
            }
            if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
            {
                // �T�E���h�J�[�h
                ErrorList.Add("�E�R�[���T�C��");
            }
            else
            {
                // OK
                Console.WriteLine("OK");
            }

            // �͂�
            if (ErrorList.Count > 0)
            {
                // �G���[
                MessageBox.Show("���L�ݒ�G���[���o�Ă��܂�" + Environment.NewLine
                                        + "���m�F������" + Environment.NewLine
                                        + string.Join(Environment.NewLine, ErrorList),
                                        "�ݒ�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // �R�[���T�C���ݒ肷��?
                if (string.IsNullOrWhiteSpace(SettingClass.UserCallSign))
                {
                    // ����
                    if (MessageBox.Show("�R�[���T�C���ݒ�㑗�M�\�ɂȂ�܂�"
                                        + Environment.NewLine + "�ݒ肵�܂���?",
                                        "�R�[���T�C���ݒ�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // �\��
                        new Form3().ShowDialog();

                        // �w�b�_��������
                        Name = SoftName + "(�R�[���T�C��:" + SettingClass.UserCallSign + ")";

                        // ���M
                        FAXSend();
                    }
                    else
                    {
                        // ���M�o���Ȃ�
                        return;
                    }
                }
                else
                {
                    // ���M�o���Ȃ�
                    return;
                }
            }
            else
            {
                // ���M
                FAXSend();
            }
        }

        /// <summary>
        /// FAX���M
        /// </summary>
        private void FAXSend()
        {
            // �{�^��
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
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "FAX�M��������..."));

                // �V���A���|�[�g
                SerialPortControlClass SerialPortControl = new(SettingClass.ComPort, SettingClass.ComSet, SettingClass.ComSpeed);

                // �g���C�L���b�`
                try
                {
                    // �I��
                    string FAXSignalPath = FAXSignalGenerator(IOCValue);

                    // �Đ������̐���
                    MainOutputStream = new WaveFileReader(FAXSignalPath);
                    WaveChannel32 VolumeStream = new(MainOutputStream);

                    // �C���X�^���X����
                    FAXPlayer = new();

                    // ������
                    FAXPlayer.DeviceNumber = PlaySoundCardIndexNoSelect();
                    FAXPlayer.Init(VolumeStream);

                    // COM�ݒ�?
                    if (SettingClass.ComPort.Contains("COM"))
                    {
                        // �X�^�[�g
                        SerialPortControl.SerialPortControlOpen();
                    }
                    else
                    {
                        // NG
                        Console.WriteLine("NG");
                    }

                    // �Đ�
                    FAXPlayer.Play();

                    // ��~�{�^��
                    StopButton.Invoke(new Action(() => StopButton.Enabled = true));

                    // �^�C���X�p��
                    TimeSpan TimeSpanValue = new();

                    // �����C��
                    double RemainValue = 0;

                    // �Đ����I��閘�ҋ@
                    while (FAXPlayer.PlaybackState == PlaybackState.Playing)
                    {
                        // �ݒ�
                        TimeSpanValue = MainOutputStream.TotalTime - MainOutputStream.CurrentTime;
                        RemainValue = Math.Round(MainOutputStream.CurrentTime / MainOutputStream.TotalTime * 100);
                        DoingLabel.Invoke(new Action(() => DoingLabel.Text = RemainValue + "%���M��..." + Environment.NewLine + "�c��:" + TimeSpanValue.Minutes + "��" + TimeSpanValue.Seconds + "�b"));

                        // ����
                        if (MainOutputStream.CurrentTime == MainOutputStream.TotalTime)
                        {
                            // ����
                            break;
                        }
                        else
                        {
                            // �p��
                            continue;
                        }
                    }

                    // ���M�������͑|��
                    MainOutputStream.Dispose();
                    SendPictureBox.Image = null;

                    // �ǂ���ɂ���A�t�@�C���͏���
                    if (string.IsNullOrWhiteSpace(FAXSignalPath))
                    {
                        // OK
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        // ����
                        File.Delete(FAXSignalPath);
                    }

                    // ��~����
                    if (ForceStop)
                    {
                        // �Đ����I��閘�ҋ@
                        while (true)
                        {
                            // STOP
                            Thread.Sleep(1000);

                            // ����
                            if (FAXPlayer.PlaybackState == PlaybackState.Playing)
                            {
                                // ����
                                break;
                            }
                            else
                            {
                                // �p��
                                continue;
                            }
                        }

                        // �Đ����I��閘�ҋ@
                        while (FAXPlayer.PlaybackState == PlaybackState.Playing)
                        {
                            // ����
                            if (MainOutputStream.CurrentTime == MainOutputStream.TotalTime)
                            {
                                // ����
                                break;
                            }
                            else
                            {
                                // �p��
                                continue;
                            }
                        }

                        // ������~
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
                    MessageBox.Show("�\�t�g����~���܂���" + Environment.NewLine + "���R�͉��L�̒ʂ�ł�" + Environment.NewLine + ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // �I��
                    if (FAXPlayer is null)
                    {
                        // OK
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        // ��~
                        FAXPlayer.Stop();
                        FAXPlayer.Dispose();
                    }

                    // �I��
                    if (MainOutputStream is null)
                    {
                        // OK
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        // �̂�
                        MainOutputStream.Dispose();
                    }

                    // ERRor
                    IsErrorFlag = true;

                    // �ǂ���ɂ���A�t�@�C���͏���
                    DeleteFAXFile();
                }

                // �`�F�b�N
                if (SerialPortControl.SerialPort.IsOpen)
                {
                    // ����
                    SerialPortControl.SerialPortControlClose();
                }
                else
                {
                    // OK
                    Console.WriteLine("OK");
                }

                // ����
                if (IsErrorFlag)
                {
                    // �L����
                    WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = true));
                    SendButton.Invoke(new Action(() => SendButton.Enabled = true));
                }
                else
                {
                    // ������
                    WAVEBbutton.Invoke(new Action(() => WAVEBbutton.Enabled = false));
                    SendButton.Invoke(new Action(() => SendButton.Enabled = false));
                }

                // ����
                PictSelectButton.Invoke(new Action(() => PictSelectButton.Enabled = true));
                EndButton.Invoke(new Action(() => EndButton.Enabled = true));
                StopButton.Invoke(new Action(() => StopButton.Enabled = false));
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = string.Empty));
            });
        }

        /// <summary>
        /// ��~�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            // �t���O
            ForceStop = true;

            // OK
            Task.Run(() =>
            {
                // ������~
                FAXPlayer.Stop();
                FAXPlayer.Dispose();
                MainOutputStream.Dispose();
                StopButton.Invoke(new Action(() => StopButton.Enabled = false));

                // ��~�M���𗬂�
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "��~�M�����o��..."));

                // �Đ������̐���
                MainOutputStream = new WaveFileReader(FAXStopSignalPath);
                WaveChannel32 VolumeStream = new(MainOutputStream);

                // �C���X�^���X����
                FAXPlayer = new();

                // ������
                FAXPlayer.DeviceNumber = PlaySoundCardIndexNoSelect();
                FAXPlayer.Init(VolumeStream);

                // �Đ�
                FAXPlayer.Play();

                // ���M�������͑|��
                SendPictureBox.Invoke(new Action(() => SendPictureBox.Image = null));

                // �ǂ���ɂ���A�t�@�C���͏���
                DeleteFAXFile();
            });
        }

        /// <summary>
        /// �t�@�C������
        /// </summary>
        private void DeleteFAXFile()
        {
            // ���ʃN���X�ɔ�΂�
            new CommonProcessClass().DeleteFAXFile();
        }

        /// <summary>
        /// �Đ��f�o�C�X�擾
        /// </summary>
        /// <returns></returns>
        private int PlaySoundCardIndexNoSelect()
        {
            // ���ʃN���X��
            return new CommonProcessClass().PlaySoundCardIndexNoSelect();
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

            // �ݒ�ς�
            Text = SoftName + "(�R�[���T�C��:" + SettingClass.UserCallSign + ")";
        }

        /// <summary>
        /// �����W���I��
        /// </summary>
        /// <returns></returns>
        private int ICOConboBoxGetSelectItem()
        {
            // �I��
            switch (IOCComboBox.SelectedItem.ToString())
            {
                // HAM1
                case "288(�A�}�`���A�������[�h1)":
                    return 288;

                // HAM2
                case "288/576(�A�}�`���A�������[�h2)":
                    return 288576;

                // OK
                case "576(�Ɩ��ǃ��[�h)":
                default:
                    return 576;
            }
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
            PictRotateButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            EndButton.Enabled = false;
            Task.Run(() =>
            {
                // OK
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "FAX�M��������..."));
            });

            // �I��
            string FAXSignalPath = FAXSignalGenerator(ICOConboBoxGetSelectItem());

            // �ۑ��_�C�����O
            //SaveFileDialog�N���X�̃C���X�^���X���쐬
            SaveFileDialog SignalSaveFileDialog = new();

            // �͂��߂̃t�@�C�������w�肷��
            // �͂��߂Ɂu�t�@�C�����v�ŕ\������镶������w�肷��
            SignalSaveFileDialog.FileName = Path.GetFileName(FAXSignalPath);

            //// �͂��߂ɕ\�������t�H���_���w�肷��
            // sfd.InitialDirectory = @"C:\";

            // [�t�@�C���̎��]�ɕ\�������I�������w�肷��
            // �w�肵�Ȃ��i��̕�����j�̎��́A���݂̃f�B���N�g�����\�������
            SignalSaveFileDialog.Filter = "WAV�t�@�C��(*.wav)|*.wav|���ׂẴt�@�C��(*.*)|*.*";

            // [�t�@�C���̎��]�ł͂��߂ɑI���������̂��w�肷��
            // 2�Ԗڂ́u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
            SignalSaveFileDialog.FilterIndex = 0;

            // �^�C�g����ݒ肷��
            SignalSaveFileDialog.Title = "�ۑ���̃t�@�C����I�����ĉ�����";

            // �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
            SignalSaveFileDialog.RestoreDirectory = true;

            // ���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
            // �f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            SignalSaveFileDialog.OverwritePrompt = true;

            // ���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
            // �f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            SignalSaveFileDialog.CheckPathExists = true;

            // �_�C�A���O�\��
            Task.Run(() =>
            {
                // OK
                DoingLabel.Invoke(new Action(() => DoingLabel.Text = "�ۑ���I��..."));
            });

            //�_�C�A���O��\������
            if (SignalSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OK�{�^�����N���b�N���ꂽ�Ƃ��A�I�����ꂽ�t�@�C������\������
                Console.WriteLine(SignalSaveFileDialog.FileName);

                // OK
                Task.Run(() =>
                {
                    // OK
                    DoingLabel.Invoke(new Action(() => DoingLabel.Text = "�ۑ�������..."));
                });

                // �R�s�[
                File.Copy(FAXSignalPath, SignalSaveFileDialog.FileName, true);

                // ���M�������͑|��
                SendPictureBox.Image = null;

                // �{�^������
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

            // �ǂ���ɂ���A�t�@�C���͏���
            if (string.IsNullOrWhiteSpace(FAXSignalPath))
            {
                // OK
                Console.WriteLine("OK");
            }
            else
            {
                // ����
                File.Delete(FAXSignalPath);
            }
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

                // �ۑ��֐���
                new SettingClass().IOCValueSave(((ComboBox)sender).SelectedText);
            }
        }

        /// <summary>
        /// FAX����
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        private string FAXSignalGenerator(int IOCValue)
        {
            // PictBox�ɏo�Ă���摜��ۑ�����
            string SendImagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "SendImage.png");

            // �ꎞ�ۑ�
            SendPictureBox.Image.Save(SendImagePath, System.Drawing.Imaging.ImageFormat.Png);

            // ImageFilePath
            string TempImagePath = new ImageMake().MakeImage(SendImagePath, Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            // WavePath
            string OutputFAXSignalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav");

            // FAX�M�������ɓ�������
            FaxMachine HamFaxMachine = new(16000, 1900, 400, IOCValue);

            // �M������
            HamFaxMachine.Fax(TempImagePath, OutputFAXSignalPath, new BinaryCodedHeader(null, null, null, null, null, null));

            // �e���|�����t�@�C������
            File.Delete(TempImagePath);
            File.Delete(SendImagePath);

            // �߂�
            return OutputFAXSignalPath;
        }

        /// <summary>
        /// FAX��~�M������
        /// </summary>
        /// <returns></returns>
        private string FAXStopSignalGenerator()
        {
            // �߂�
            return new CommonProcessClass().FAXStopSignalGenerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ����
            if (string.IsNullOrWhiteSpace(FAXStopSignalPath))
            {
                // end
                return;
            }
            else
            {
                // ����
                File.Delete(FAXStopSignalPath);

                // ����
                FAXStopSignalPath = string.Empty;
            }
        }

        /// <summary>
        /// �I�����C���w���v�\��
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