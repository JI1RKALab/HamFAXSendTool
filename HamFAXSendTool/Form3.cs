namespace HamFAXSendTool
{
    public partial class Form3 : Form
    {
        /// <summary>
        /// Backspace キー
        /// </summary>
        const char BACKSPACE = '\b';

        /// <summary>
        /// CTRL+ C
        /// </summary>
        const char CTRL_C = '\x03';

        /// <summary>
        /// CTRL+ V
        /// </summary>
        const char CTRL_V = '\x16';

        /// <summary>
        /// CTRL+ X
        /// </summary>
        const char CTRL_X = '\x18';

        /// <summary>
        /// CTRL+ Z
        /// </summary>
        const char CTRL_Z = '\x1A';

        /// <summary>
        /// インスタンス生成
        /// </summary>
        public Form3()
        {
            // 初期化
            InitializeComponent();
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_Load(object sender, EventArgs e)
        {
            // setting
            CallSignInputTextBox.Text = string.IsNullOrWhiteSpace(SettingClass.UserCallSign) 
                                                    ? string.Empty : SettingClass.UserCallSign;

            // OK
            CallSignInputTextBox.Select(CallSignInputTextBox.Text.Length, 0);
        }

        /// <summary>
        /// バリデーションチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallSignInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // wip
            switch (e.KeyChar)
            {
                // 判定
                case BACKSPACE:
                case CTRL_C:
                case CTRL_V:
                case CTRL_X:
                case CTRL_Z:
                    // OK
                    break;
                default:
                    // OK
                    if (!IsValidChar(e.KeyChar))
                    {
                        // OK
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        // OK
                        e.Handled = false;
                    }

                    // 抜け
                    break;
            }

            // end
            base.OnKeyPress(e);
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="InputChar"></param>
        /// <returns></returns>
        private bool IsValidChar(char InputChar)
        {
            // OK
            return (InputChar >= 'A' && InputChar <= 'Z') || (InputChar >= 'a' && InputChar <= 'z') || (InputChar >= '0' && InputChar <= '9');
        }

        /// <summary>
        /// コールサイン登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingButton_Click(object sender, EventArgs e)
        {
            // 判定
            if (string.IsNullOrWhiteSpace(CallSignInputTextBox.Text))
            {
                // 入っていない
                MessageBox.Show("コールサイン未入力です!", "未入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // 登録
                new SettingClass().CallSignSettingFileSave(CallSignInputTextBox.Text.ToUpper());

                // 閉じる
                Close();
            }
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // 閉じる
            Close();
        }
    }
}