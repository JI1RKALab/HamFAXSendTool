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
            ((System.ComponentModel.ISupportInitialize)SendPictureBox).BeginInit();
            SuspendLayout();
            // 
            // SendLabel
            // 
            SendLabel.AutoSize = true;
            SendLabel.Font = new Font("Yu Gothic UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            SendLabel.Location = new Point(3, 6);
            SendLabel.Name = "SendLabel";
            SendLabel.Size = new Size(152, 37);
            SendLabel.TabIndex = 0;
            SendLabel.Text = "←送信方向";
            SendLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DoingLabel
            // 
            DoingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DoingLabel.AutoSize = true;
            DoingLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DoingLabel.Location = new Point(868, 337);
            DoingLabel.Name = "DoingLabel";
            DoingLabel.Size = new Size(0, 21);
            DoingLabel.TabIndex = 6;
            // 
            // IOCTitleLable
            // 
            IOCTitleLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IOCTitleLable.AutoSize = true;
            IOCTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IOCTitleLable.Location = new Point(868, 113);
            IOCTitleLable.Name = "IOCTitleLable";
            IOCTitleLable.Size = new Size(78, 21);
            IOCTitleLable.TabIndex = 3;
            IOCTitleLable.Text = "協動係数:";
            // 
            // IOCComboBox
            // 
            IOCComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IOCComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IOCComboBox.FormattingEnabled = true;
            IOCComboBox.Items.AddRange(new object[] { "288(アマチュア無線モード1)", "288/576(アマチュア無線モード2)", "576(業務局モード)" });
            IOCComboBox.Location = new Point(868, 145);
            IOCComboBox.Margin = new Padding(3, 2, 3, 2);
            IOCComboBox.Name = "IOCComboBox";
            IOCComboBox.Size = new Size(190, 23);
            IOCComboBox.TabIndex = 4;
            IOCComboBox.SelectedIndexChanged += IOCComboBox_SelectedIndexChanged;
            // 
            // StatusTitleLable
            // 
            StatusTitleLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StatusTitleLable.AutoSize = true;
            StatusTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTitleLable.Location = new Point(868, 303);
            StatusTitleLable.Name = "StatusTitleLable";
            StatusTitleLable.Size = new Size(73, 21);
            StatusTitleLable.TabIndex = 6;
            StatusTitleLable.Text = "スタータス:";
            // 
            // EndButton
            // 
            EndButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EndButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            EndButton.Location = new Point(868, 439);
            EndButton.Margin = new Padding(3, 2, 3, 2);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(190, 36);
            EndButton.TabIndex = 8;
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
            StopButton.Location = new Point(868, 379);
            StopButton.Margin = new Padding(3, 2, 3, 2);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(190, 36);
            StopButton.TabIndex = 7;
            StopButton.Text = "停止";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // SendButton
            // 
            SendButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SendButton.Enabled = false;
            SendButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SendButton.Location = new Point(868, 247);
            SendButton.Margin = new Padding(3, 2, 3, 2);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(190, 36);
            SendButton.TabIndex = 5;
            SendButton.Text = "送信";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // PictSelectButton
            // 
            PictSelectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictSelectButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            PictSelectButton.Location = new Point(868, 4);
            PictSelectButton.Margin = new Padding(3, 2, 3, 2);
            PictSelectButton.Name = "PictSelectButton";
            PictSelectButton.Size = new Size(190, 36);
            PictSelectButton.TabIndex = 2;
            PictSelectButton.Text = "画像選択";
            PictSelectButton.UseVisualStyleBackColor = true;
            PictSelectButton.Click += PictSelectButton_Click;
            // 
            // SendPictureBox
            // 
            SendPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SendPictureBox.Location = new Point(1, 42);
            SendPictureBox.Margin = new Padding(3, 2, 3, 2);
            SendPictureBox.Name = "SendPictureBox";
            SendPictureBox.Size = new Size(665, 433);
            SendPictureBox.TabIndex = 12;
            SendPictureBox.TabStop = false;
            // 
            // PictCheckedListBox
            // 
            PictCheckedListBox.FormattingEnabled = true;
            PictCheckedListBox.HorizontalScrollbar = true;
            PictCheckedListBox.Location = new Point(672, 42);
            PictCheckedListBox.Name = "PictCheckedListBox";
            PictCheckedListBox.Size = new Size(190, 418);
            PictCheckedListBox.TabIndex = 1;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserControl1";
            Size = new Size(1058, 478);
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
    }
}
