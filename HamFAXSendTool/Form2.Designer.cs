namespace HamFAXSendTool
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComPortLabel = new Label();
            ComPortListBox = new ListBox();
            SoundCardListBox = new ListBox();
            SoundCardLabel = new Label();
            SettingButton = new Button();
            CloseButton = new Button();
            ComTestLabel = new Label();
            ComTestButton = new Button();
            ComVerListBox = new ListBox();
            ComVerLabel = new Label();
            ComSpeedLabel = new Label();
            BPSTextBox = new TextBox();
            SuspendLayout();
            // 
            // ComPortLabel
            // 
            ComPortLabel.AutoSize = true;
            ComPortLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComPortLabel.Location = new Point(12, 9);
            ComPortLabel.Name = "ComPortLabel";
            ComPortLabel.Size = new Size(136, 25);
            ComPortLabel.TabIndex = 0;
            ComPortLabel.Text = "COMポート設定";
            // 
            // ComPortListBox
            // 
            ComPortListBox.FormattingEnabled = true;
            ComPortListBox.ItemHeight = 20;
            ComPortListBox.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20", "COM21", "COM22", "COM23", "COM24", "COM25", "COM26", "COM27", "COM28", "COM29", "COM30" });
            ComPortListBox.Location = new Point(12, 52);
            ComPortListBox.Name = "ComPortListBox";
            ComPortListBox.Size = new Size(193, 284);
            ComPortListBox.TabIndex = 1;
            // 
            // SoundCardListBox
            // 
            SoundCardListBox.FormattingEnabled = true;
            SoundCardListBox.ItemHeight = 20;
            SoundCardListBox.Location = new Point(470, 52);
            SoundCardListBox.Name = "SoundCardListBox";
            SoundCardListBox.Size = new Size(306, 284);
            SoundCardListBox.TabIndex = 7;
            // 
            // SoundCardLabel
            // 
            SoundCardLabel.AutoSize = true;
            SoundCardLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            SoundCardLabel.Location = new Point(470, 9);
            SoundCardLabel.Name = "SoundCardLabel";
            SoundCardLabel.Size = new Size(150, 25);
            SoundCardLabel.TabIndex = 6;
            SoundCardLabel.Text = "サウンドカード設定";
            // 
            // SettingButton
            // 
            SettingButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            SettingButton.Location = new Point(366, 423);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(193, 48);
            SettingButton.TabIndex = 10;
            SettingButton.Text = "設定";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.Location = new Point(583, 423);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(193, 48);
            CloseButton.TabIndex = 11;
            CloseButton.Text = "閉じる";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ComTestLabel
            // 
            ComTestLabel.AutoSize = true;
            ComTestLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComTestLabel.Location = new Point(12, 368);
            ComTestLabel.Name = "ComTestLabel";
            ComTestLabel.Size = new Size(141, 25);
            ComTestLabel.TabIndex = 8;
            ComTestLabel.Text = "COMポートテスト";
            // 
            // ComTestButton
            // 
            ComTestButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComTestButton.Location = new Point(159, 356);
            ComTestButton.Name = "ComTestButton";
            ComTestButton.Size = new Size(193, 48);
            ComTestButton.TabIndex = 9;
            ComTestButton.Text = "テスト開始";
            ComTestButton.UseVisualStyleBackColor = true;
            ComTestButton.Click += ComTestButton_Click;
            // 
            // ComVerListBox
            // 
            ComVerListBox.FormattingEnabled = true;
            ComVerListBox.ItemHeight = 20;
            ComVerListBox.Items.AddRange(new object[] { "RTS", "DTS" });
            ComVerListBox.Location = new Point(243, 52);
            ComVerListBox.Name = "ComVerListBox";
            ComVerListBox.Size = new Size(193, 104);
            ComVerListBox.TabIndex = 3;
            // 
            // ComVerLabel
            // 
            ComVerLabel.AutoSize = true;
            ComVerLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComVerLabel.Location = new Point(243, 9);
            ComVerLabel.Name = "ComVerLabel";
            ComVerLabel.Size = new Size(126, 25);
            ComVerLabel.TabIndex = 2;
            ComVerLabel.Text = "通信方法設定";
            // 
            // ComSpeedLabel
            // 
            ComSpeedLabel.AutoSize = true;
            ComSpeedLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComSpeedLabel.Location = new Point(243, 181);
            ComSpeedLabel.Name = "ComSpeedLabel";
            ComSpeedLabel.Size = new Size(130, 25);
            ComSpeedLabel.TabIndex = 4;
            ComSpeedLabel.Text = "通信速度(bps)";
            // 
            // BPSTextBox
            // 
            BPSTextBox.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            BPSTextBox.ImeMode = ImeMode.Disable;
            BPSTextBox.Location = new Point(244, 221);
            BPSTextBox.Name = "BPSTextBox";
            BPSTextBox.ShortcutsEnabled = false;
            BPSTextBox.Size = new Size(192, 32);
            BPSTextBox.TabIndex = 5;
            BPSTextBox.KeyPress += BPSTextBox_KeyPress;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 491);
            Controls.Add(BPSTextBox);
            Controls.Add(ComSpeedLabel);
            Controls.Add(ComVerListBox);
            Controls.Add(ComVerLabel);
            Controls.Add(ComTestButton);
            Controls.Add(ComTestLabel);
            Controls.Add(CloseButton);
            Controls.Add(SettingButton);
            Controls.Add(SoundCardListBox);
            Controls.Add(SoundCardLabel);
            Controls.Add(ComPortListBox);
            Controls.Add(ComPortLabel);
            MaximizeBox = false;
            Name = "Form2";
            Text = "COM・サウンドカード設定";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ComPortLabel;
        private ListBox ComPortListBox;
        private ListBox SoundCardListBox;
        private Label SoundCardLabel;
        private Button SettingButton;
        private Button CloseButton;
        private Label ComTestLabel;
        private Button ComTestButton;
        private ListBox ComVerListBox;
        private Label ComVerLabel;
        private Label ComSpeedLabel;
        private TextBox BPSTextBox;
    }
}