namespace HamFAXSendTool
{
    public partial class Form3 : Form
    {
        /// <summary>
        /// インスタンス生成
        /// </summary>
        public Form3()
        {
            // 初期化
            InitializeComponent();
        }

        /// <summary>
        /// バリデーションチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallSignInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // wip
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
                new SettingClass().CallSignSettingFileSave(CallSignInputTextBox.Text);

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