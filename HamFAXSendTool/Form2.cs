using System.Data;

namespace HamFAXSendTool
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// シリアルポート
        /// </summary>
        SerialPortControlClass SerialPortController = null;

        /// <summary>
        /// Comポート
        /// </summary>
        bool ComPortChecker = new();

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

            // 読み込み
            if (string.IsNullOrWhiteSpace(SettingClass.ComPort))
            {
                // index
                ComPortListBox.SelectedIndex = -1;
            }
            else
            {
                // set
                ComPortListBox.SelectedItem = SettingClass.ComPort;
            }
            if (string.IsNullOrWhiteSpace(SettingClass.ComSet))
            {
                // index
                ComVerListBox.SelectedIndex = -1;
            }
            else
            {
                // OK
                ComVerListBox.SelectedItem = SettingClass.ComSet;
            }
            if (SettingClass.ComSpeed > 0)
            {
                // ok
                BPSTextBox.Text = SettingClass.ComSpeed.ToString();
            }
            else
            {
                // ok
                BPSTextBox.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(SettingClass.SoundCard))
            {
                // ok
                SoundCardListBox.SelectedIndex = -1;
            }
            else
            {
                // ok
                SoundCardListBox.SelectedItem = SettingClass.SoundCard;
            }

            // check
            if (!string.IsNullOrWhiteSpace(SettingClass.ComPort) &&
                !string.IsNullOrWhiteSpace(SettingClass.ComSet) &&
                SettingClass.ComSpeed > 0)
            {
                // OK
                SerialPortController = new(ComPortListBox.SelectedItem.ToString(),
                                                            ComVerListBox.SelectedItem.ToString(),
                                                            int.Parse(BPSTextBox.Text));
            }
            else
            {
                // Skip
                Console.Write("Skip");
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
                // start
                try
                {
                    // OK
                    if (SerialPortController is null)
                    {
                        // Error
                        MessageBox.Show("COMポートに未設定項目があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // OK
                        if (ComPortChecker)
                        {
                            // OK
                            SerialPortController.SerialPortControlClose();
                            ((Button)sender).Text = "テスト開始";
                            ((Button)sender).BackColor = SystemColors.Control;
                            ((Button)sender).ForeColor = SystemColors.ControlText;
                            SettingButton.Enabled = true;
                            CloseButton.Enabled = true;
                            ComPortChecker = false;
                            new SettingClass().SettingFileSave(ComPortListBox.SelectedItem.ToString(),
                                                                ComVerListBox.SelectedItem.ToString(),
                                                                int.Parse(BPSTextBox.Text),
                                                                SoundCardListBox.SelectedItem.ToString());
                        }
                        else
                        {
                            // 上書き
                            SerialPortController = new(ComPortListBox.SelectedItem.ToString(),
                                                                        ComVerListBox.SelectedItem.ToString(),
                                                                        int.Parse(BPSTextBox.Text));

                            // OK
                            SerialPortController.SerialPortControlOpen();
                            ((Button)sender).Text = "テスト停止";
                            ((Button)sender).BackColor = Color.Red;
                            ((Button)sender).ForeColor = Color.White;
                            SettingButton.Enabled = false;
                            CloseButton.Enabled = false;
                            ComPortChecker = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Error
                    MessageBox.Show("下記エラーが発生しました" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                // 保存
                new SettingClass().SettingFileSave(ComPortListBox.SelectedItem.ToString(),
                                                    ComVerListBox.SelectedItem.ToString(),
                                                    int.Parse(BPSTextBox.Text),
                                                    SoundCardListBox.SelectedItem.ToString());

                // 閉じる
                Close();
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
            Close();
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