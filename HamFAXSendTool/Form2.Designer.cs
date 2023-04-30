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
            ComPortListBox.Location = new Point(12, 52);
            ComPortListBox.Name = "ComPortListBox";
            ComPortListBox.Size = new Size(193, 284);
            ComPortListBox.TabIndex = 1;
            // 
            // SoundCardListBox
            // 
            SoundCardListBox.FormattingEnabled = true;
            SoundCardListBox.ItemHeight = 20;
            SoundCardListBox.Location = new Point(242, 52);
            SoundCardListBox.Name = "SoundCardListBox";
            SoundCardListBox.Size = new Size(306, 284);
            SoundCardListBox.TabIndex = 3;
            // 
            // SoundCardLabel
            // 
            SoundCardLabel.AutoSize = true;
            SoundCardLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            SoundCardLabel.Location = new Point(242, 9);
            SoundCardLabel.Name = "SoundCardLabel";
            SoundCardLabel.Size = new Size(150, 25);
            SoundCardLabel.TabIndex = 2;
            SoundCardLabel.Text = "サウンドカード設定";
            // 
            // SettingButton
            // 
            SettingButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            SettingButton.Location = new Point(39, 444);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(193, 48);
            SettingButton.TabIndex = 5;
            SettingButton.Text = "設定";
            SettingButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.Location = new Point(355, 444);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(193, 48);
            CloseButton.TabIndex = 6;
            CloseButton.Text = "閉じる";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // ComTestLabel
            // 
            ComTestLabel.AutoSize = true;
            ComTestLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComTestLabel.Location = new Point(12, 356);
            ComTestLabel.Name = "ComTestLabel";
            ComTestLabel.Size = new Size(141, 25);
            ComTestLabel.TabIndex = 7;
            ComTestLabel.Text = "COMポートテスト";
            // 
            // ComTestButton
            // 
            ComTestButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ComTestButton.Location = new Point(199, 372);
            ComTestButton.Name = "ComTestButton";
            ComTestButton.Size = new Size(193, 48);
            ComTestButton.TabIndex = 8;
            ComTestButton.Text = "テスト";
            ComTestButton.UseVisualStyleBackColor = true;
            ComTestButton.Click += ComTestButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 515);
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
            Text = "Form2";
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
    }
}