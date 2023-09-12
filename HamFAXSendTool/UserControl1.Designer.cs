namespace HamFAXSendTool
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            SendLabel = new Label();
            DoingLabel = new Label();
            IOCTitleLable = new Label();
            IOCComboBox = new ComboBox();
            StatusTitleLable = new Label();
            EndButton = new Button();
            StopButton = new Button();
            SendButton = new Button();
            PictSelectButton = new Button();
            SendPictureBox = new PictureBox();
            PictCheckedListBox = new CheckedListBox();
            RPMSelectLabel = new Label();
            RPMSelectComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)SendPictureBox).BeginInit();
            SuspendLayout();
            // 
            // SendLabel
            // 
            SendLabel.AutoSize = true;
            SendLabel.Font = new Font("Yu Gothic UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            SendLabel.Location = new Point(3, 8);
            SendLabel.Name = "SendLabel";
            SendLabel.Size = new Size(190, 46);
            SendLabel.TabIndex = 0;
            SendLabel.Text = "←送信方向";
            SendLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DoingLabel
            // 
            DoingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DoingLabel.AutoSize = true;
            DoingLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DoingLabel.Location = new Point(992, 449);
            DoingLabel.Name = "DoingLabel";
            DoingLabel.Size = new Size(0, 28);
            DoingLabel.TabIndex = 9;
            // 
            // IOCTitleLable
            // 
            IOCTitleLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IOCTitleLable.AutoSize = true;
            IOCTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IOCTitleLable.Location = new Point(992, 198);
            IOCTitleLable.Name = "IOCTitleLable";
            IOCTitleLable.Size = new Size(97, 28);
            IOCTitleLable.TabIndex = 5;
            IOCTitleLable.Text = "協動係数:";
            // 
            // IOCComboBox
            // 
            IOCComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IOCComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IOCComboBox.FormattingEnabled = true;
            IOCComboBox.Items.AddRange(new object[] { "288(アマチュア無線モード1)", "288/576(アマチュア無線モード2)", "576(業務局モード)" });
            IOCComboBox.Location = new Point(992, 240);
            IOCComboBox.Name = "IOCComboBox";
            IOCComboBox.Size = new Size(217, 28);
            IOCComboBox.TabIndex = 6;
            IOCComboBox.SelectedIndexChanged += IOCComboBox_SelectedIndexChanged;
            // 
            // StatusTitleLable
            // 
            StatusTitleLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StatusTitleLable.AutoSize = true;
            StatusTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTitleLable.Location = new Point(992, 404);
            StatusTitleLable.Name = "StatusTitleLable";
            StatusTitleLable.Size = new Size(92, 28);
            StatusTitleLable.TabIndex = 8;
            StatusTitleLable.Text = "スタータス:";
            // 
            // EndButton
            // 
            EndButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EndButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            EndButton.Location = new Point(992, 585);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(217, 48);
            EndButton.TabIndex = 11;
            EndButton.Text = "終了";
            EndButton.UseVisualStyleBackColor = true;
            EndButton.Click += EndButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StopButton.AutoSize = true;
            StopButton.Enabled = false;
            StopButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            StopButton.Location = new Point(992, 505);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(217, 48);
            StopButton.TabIndex = 10;
            StopButton.Text = "停止";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // SendButton
            // 
            SendButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SendButton.Enabled = false;
            SendButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SendButton.Location = new Point(992, 329);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(217, 48);
            SendButton.TabIndex = 7;
            SendButton.Text = "送信";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // PictSelectButton
            // 
            PictSelectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictSelectButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            PictSelectButton.Location = new Point(992, 5);
            PictSelectButton.Name = "PictSelectButton";
            PictSelectButton.Size = new Size(217, 48);
            PictSelectButton.TabIndex = 2;
            PictSelectButton.Text = "画像選択";
            PictSelectButton.UseVisualStyleBackColor = true;
            PictSelectButton.Click += PictSelectButton_Click;
            // 
            // SendPictureBox
            // 
            SendPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SendPictureBox.Location = new Point(1, 56);
            SendPictureBox.Name = "SendPictureBox";
            SendPictureBox.Size = new Size(760, 577);
            SendPictureBox.TabIndex = 12;
            SendPictureBox.TabStop = false;
            // 
            // PictCheckedListBox
            // 
            PictCheckedListBox.FormattingEnabled = true;
            PictCheckedListBox.HorizontalScrollbar = true;
            PictCheckedListBox.Location = new Point(768, 56);
            PictCheckedListBox.Margin = new Padding(3, 4, 3, 4);
            PictCheckedListBox.Name = "PictCheckedListBox";
            PictCheckedListBox.Size = new Size(217, 554);
            PictCheckedListBox.TabIndex = 1;
            PictCheckedListBox.ItemCheck += PictCheckedListBox_ItemCheck;
            // 
            // RPMSelectLabel
            // 
            RPMSelectLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RPMSelectLabel.AutoSize = true;
            RPMSelectLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            RPMSelectLabel.Location = new Point(992, 89);
            RPMSelectLabel.Name = "RPMSelectLabel";
            RPMSelectLabel.Size = new Size(77, 28);
            RPMSelectLabel.TabIndex = 3;
            RPMSelectLabel.Text = "回転数:";
            // 
            // RPMSelectComboBox
            // 
            RPMSelectComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RPMSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RPMSelectComboBox.FormattingEnabled = true;
            RPMSelectComboBox.Items.AddRange(new object[] { "60回転", "120回転", "240回転", "360回転" });
            RPMSelectComboBox.Location = new Point(992, 131);
            RPMSelectComboBox.Name = "RPMSelectComboBox";
            RPMSelectComboBox.Size = new Size(217, 28);
            RPMSelectComboBox.TabIndex = 4;
            RPMSelectComboBox.SelectedIndexChanged += RPMSelectComboBox_SelectedIndexChanged;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RPMSelectLabel);
            Controls.Add(RPMSelectComboBox);
            Controls.Add(PictCheckedListBox);
            Controls.Add(SendLabel);
            Controls.Add(DoingLabel);
            Controls.Add(IOCTitleLable);
            Controls.Add(IOCComboBox);
            Controls.Add(StatusTitleLable);
            Controls.Add(EndButton);
            Controls.Add(StopButton);
            Controls.Add(SendButton);
            Controls.Add(PictSelectButton);
            Controls.Add(SendPictureBox);
            Name = "UserControl1";
            Size = new Size(1209, 637);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)SendPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SendLabel;
        private Label DoingLabel;
        private Label IOCTitleLable;
        private ComboBox IOCComboBox;
        private Label StatusTitleLable;
        private Button EndButton;
        private Button StopButton;
        private Button SendButton;
        private Button PictSelectButton;
        private PictureBox SendPictureBox;
        private CheckedListBox PictCheckedListBox;
        private Label RPMSelectLabel;
        private ComboBox RPMSelectComboBox;
    }
}
