namespace HamFAXSendTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SendPictureBox = new PictureBox();
            PictSelectButton = new Button();
            SendButton = new Button();
            StopButton = new Button();
            EndButton = new Button();
            StatusTitleLable = new Label();
            IOCComboBox = new ComboBox();
            IOCTitleLable = new Label();
            WAVEBbutton = new Button();
            TopMenuStrip = new MenuStrip();
            設定メニューMToolStripMenuItem = new ToolStripMenuItem();
            ComPoatSettingStripMenu = new ToolStripMenuItem();
            ヘルプHToolStripMenuItem = new ToolStripMenuItem();
            DispOnLineHelpToolStripMenuItem = new ToolStripMenuItem();
            DoingLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)SendPictureBox).BeginInit();
            TopMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // SendPictureBox
            // 
            SendPictureBox.Location = new Point(12, 38);
            SendPictureBox.Name = "SendPictureBox";
            SendPictureBox.Size = new Size(967, 548);
            SendPictureBox.TabIndex = 0;
            SendPictureBox.TabStop = false;
            // 
            // PictSelectButton
            // 
            PictSelectButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            PictSelectButton.Location = new Point(1006, 38);
            PictSelectButton.Name = "PictSelectButton";
            PictSelectButton.Size = new Size(193, 48);
            PictSelectButton.TabIndex = 1;
            PictSelectButton.Text = "画像選択";
            PictSelectButton.UseVisualStyleBackColor = true;
            PictSelectButton.Click += PictSelectButton_Click;
            // 
            // SendButton
            // 
            SendButton.Enabled = false;
            SendButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SendButton.Location = new Point(1006, 283);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(193, 48);
            SendButton.TabIndex = 5;
            SendButton.Text = "送信";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // StopButton
            // 
            StopButton.AutoSize = true;
            StopButton.Enabled = false;
            StopButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            StopButton.Location = new Point(1006, 458);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(193, 48);
            StopButton.TabIndex = 8;
            StopButton.Text = "停止";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // EndButton
            // 
            EndButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            EndButton.Location = new Point(1006, 538);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(193, 48);
            EndButton.TabIndex = 9;
            EndButton.Text = "終了";
            EndButton.UseVisualStyleBackColor = true;
            EndButton.Click += EndButton_Click;
            // 
            // StatusTitleLable
            // 
            StatusTitleLable.AutoSize = true;
            StatusTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTitleLable.Location = new Point(1006, 357);
            StatusTitleLable.Name = "StatusTitleLable";
            StatusTitleLable.Size = new Size(92, 28);
            StatusTitleLable.TabIndex = 6;
            StatusTitleLable.Text = "スタータス:";
            // 
            // IOCComboBox
            // 
            IOCComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IOCComboBox.FormattingEnabled = true;
            IOCComboBox.Items.AddRange(new object[] { "288(アマチュア無線モード)", "576(業務局モード)" });
            IOCComboBox.Location = new Point(1006, 147);
            IOCComboBox.Name = "IOCComboBox";
            IOCComboBox.Size = new Size(193, 28);
            IOCComboBox.TabIndex = 3;
            IOCComboBox.SelectedIndexChanged += IOCComboBox_SelectedIndexChanged;
            // 
            // IOCTitleLable
            // 
            IOCTitleLable.AutoSize = true;
            IOCTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IOCTitleLable.Location = new Point(1006, 104);
            IOCTitleLable.Name = "IOCTitleLable";
            IOCTitleLable.Size = new Size(97, 28);
            IOCTitleLable.TabIndex = 2;
            IOCTitleLable.Text = "協動係数:";
            // 
            // WAVEBbutton
            // 
            WAVEBbutton.Enabled = false;
            WAVEBbutton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            WAVEBbutton.Location = new Point(1006, 207);
            WAVEBbutton.Name = "WAVEBbutton";
            WAVEBbutton.Size = new Size(193, 48);
            WAVEBbutton.TabIndex = 4;
            WAVEBbutton.Text = "FAX信号保存";
            WAVEBbutton.UseVisualStyleBackColor = true;
            WAVEBbutton.Click += WAVEBbutton_Click;
            // 
            // TopMenuStrip
            // 
            TopMenuStrip.ImageScalingSize = new Size(20, 20);
            TopMenuStrip.Items.AddRange(new ToolStripItem[] { 設定メニューMToolStripMenuItem, ヘルプHToolStripMenuItem });
            TopMenuStrip.Location = new Point(0, 0);
            TopMenuStrip.Name = "TopMenuStrip";
            TopMenuStrip.Size = new Size(1211, 28);
            TopMenuStrip.TabIndex = 0;
            TopMenuStrip.Text = "menuStrip1";
            // 
            // 設定メニューMToolStripMenuItem
            // 
            設定メニューMToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ComPoatSettingStripMenu });
            設定メニューMToolStripMenuItem.Name = "設定メニューMToolStripMenuItem";
            設定メニューMToolStripMenuItem.Size = new Size(118, 24);
            設定メニューMToolStripMenuItem.Text = "設定メニュー(&M)";
            // 
            // ComPoatSettingStripMenu
            // 
            ComPoatSettingStripMenu.Name = "ComPoatSettingStripMenu";
            ComPoatSettingStripMenu.Size = new Size(140, 26);
            ComPoatSettingStripMenu.Text = "設定(&S)";
            ComPoatSettingStripMenu.Click += SettingStripMenu_Click;
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DispOnLineHelpToolStripMenuItem });
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(79, 24);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // DispOnLineHelpToolStripMenuItem
            // 
            DispOnLineHelpToolStripMenuItem.Name = "DispOnLineHelpToolStripMenuItem";
            DispOnLineHelpToolStripMenuItem.Size = new Size(222, 26);
            DispOnLineHelpToolStripMenuItem.Text = "オンラインヘルプを表示";
            DispOnLineHelpToolStripMenuItem.Click += DispOnLineHelpToolStripMenuItem_Click;
            // 
            // DoingLabel
            // 
            DoingLabel.AutoSize = true;
            DoingLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DoingLabel.Location = new Point(1006, 402);
            DoingLabel.Name = "DoingLabel";
            DoingLabel.Size = new Size(0, 28);
            DoingLabel.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 605);
            Controls.Add(DoingLabel);
            Controls.Add(WAVEBbutton);
            Controls.Add(IOCTitleLable);
            Controls.Add(IOCComboBox);
            Controls.Add(StatusTitleLable);
            Controls.Add(EndButton);
            Controls.Add(StopButton);
            Controls.Add(SendButton);
            Controls.Add(PictSelectButton);
            Controls.Add(SendPictureBox);
            Controls.Add(TopMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = TopMenuStrip;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)SendPictureBox).EndInit();
            TopMenuStrip.ResumeLayout(false);
            TopMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox SendPictureBox;
        private Button PictSelectButton;
        private Button SendButton;
        private Button StopButton;
        private Button EndButton;
        private Label StatusTitleLable;
        private ComboBox IOCComboBox;
        private Label IOCTitleLable;
        private Button WAVEBbutton;
        private MenuStrip TopMenuStrip;
        private ToolStripMenuItem 設定メニューMToolStripMenuItem;
        private ToolStripMenuItem ComPoatSettingStripMenu;
        private ToolStripMenuItem ヘルプHToolStripMenuItem;
        private Label DoingLabel;
        private ToolStripMenuItem DispOnLineHelpToolStripMenuItem;
    }
}