﻿namespace HamFAXSendTool
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
            PictRotateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SendPictureBox).BeginInit();
            TopMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // SendPictureBox
            // 
            SendPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SendPictureBox.Location = new Point(10, 28);
            SendPictureBox.Margin = new Padding(3, 2, 3, 2);
            SendPictureBox.Name = "SendPictureBox";
            SendPictureBox.Size = new Size(846, 471);
            SendPictureBox.TabIndex = 0;
            SendPictureBox.TabStop = false;
            // 
            // PictSelectButton
            // 
            PictSelectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictSelectButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            PictSelectButton.Location = new Point(880, 28);
            PictSelectButton.Margin = new Padding(3, 2, 3, 2);
            PictSelectButton.Name = "PictSelectButton";
            PictSelectButton.Size = new Size(169, 36);
            PictSelectButton.TabIndex = 1;
            PictSelectButton.Text = "画像選択";
            PictSelectButton.UseVisualStyleBackColor = true;
            PictSelectButton.Click += PictSelectButton_Click;
            // 
            // SendButton
            // 
            SendButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SendButton.Enabled = false;
            SendButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SendButton.Location = new Point(880, 271);
            SendButton.Margin = new Padding(3, 2, 3, 2);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(169, 36);
            SendButton.TabIndex = 6;
            SendButton.Text = "送信";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StopButton.AutoSize = true;
            StopButton.Enabled = false;
            StopButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            StopButton.Location = new Point(880, 403);
            StopButton.Margin = new Padding(3, 2, 3, 2);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(169, 36);
            StopButton.TabIndex = 9;
            StopButton.Text = "停止";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // EndButton
            // 
            EndButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EndButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            EndButton.Location = new Point(880, 463);
            EndButton.Margin = new Padding(3, 2, 3, 2);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(169, 36);
            EndButton.TabIndex = 10;
            EndButton.Text = "終了";
            EndButton.UseVisualStyleBackColor = true;
            EndButton.Click += EndButton_Click;
            // 
            // StatusTitleLable
            // 
            StatusTitleLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StatusTitleLable.AutoSize = true;
            StatusTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTitleLable.Location = new Point(880, 327);
            StatusTitleLable.Name = "StatusTitleLable";
            StatusTitleLable.Size = new Size(73, 21);
            StatusTitleLable.TabIndex = 7;
            StatusTitleLable.Text = "スタータス:";
            // 
            // IOCComboBox
            // 
            IOCComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IOCComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IOCComboBox.FormattingEnabled = true;
            IOCComboBox.Items.AddRange(new object[] { "288(アマチュア無線モード)", "576(業務局モード)" });
            IOCComboBox.Location = new Point(880, 169);
            IOCComboBox.Margin = new Padding(3, 2, 3, 2);
            IOCComboBox.Name = "IOCComboBox";
            IOCComboBox.Size = new Size(169, 23);
            IOCComboBox.TabIndex = 4;
            IOCComboBox.SelectedIndexChanged += IOCComboBox_SelectedIndexChanged;
            // 
            // IOCTitleLable
            // 
            IOCTitleLable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IOCTitleLable.AutoSize = true;
            IOCTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IOCTitleLable.Location = new Point(880, 137);
            IOCTitleLable.Name = "IOCTitleLable";
            IOCTitleLable.Size = new Size(78, 21);
            IOCTitleLable.TabIndex = 3;
            IOCTitleLable.Text = "協動係数:";
            // 
            // WAVEBbutton
            // 
            WAVEBbutton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WAVEBbutton.Enabled = false;
            WAVEBbutton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            WAVEBbutton.Location = new Point(880, 214);
            WAVEBbutton.Margin = new Padding(3, 2, 3, 2);
            WAVEBbutton.Name = "WAVEBbutton";
            WAVEBbutton.Size = new Size(169, 36);
            WAVEBbutton.TabIndex = 5;
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
            TopMenuStrip.Padding = new Padding(5, 2, 0, 2);
            TopMenuStrip.Size = new Size(1060, 24);
            TopMenuStrip.TabIndex = 0;
            TopMenuStrip.Text = "menuStrip1";
            // 
            // 設定メニューMToolStripMenuItem
            // 
            設定メニューMToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ComPoatSettingStripMenu });
            設定メニューMToolStripMenuItem.Name = "設定メニューMToolStripMenuItem";
            設定メニューMToolStripMenuItem.Size = new Size(95, 20);
            設定メニューMToolStripMenuItem.Text = "設定メニュー(&M)";
            // 
            // ComPoatSettingStripMenu
            // 
            ComPoatSettingStripMenu.Name = "ComPoatSettingStripMenu";
            ComPoatSettingStripMenu.Size = new Size(112, 22);
            ComPoatSettingStripMenu.Text = "設定(&S)";
            ComPoatSettingStripMenu.Click += SettingStripMenu_Click;
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DispOnLineHelpToolStripMenuItem });
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(65, 20);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // DispOnLineHelpToolStripMenuItem
            // 
            DispOnLineHelpToolStripMenuItem.Name = "DispOnLineHelpToolStripMenuItem";
            DispOnLineHelpToolStripMenuItem.Size = new Size(180, 22);
            DispOnLineHelpToolStripMenuItem.Text = "オンラインヘルプを表示";
            DispOnLineHelpToolStripMenuItem.Click += DispOnLineHelpToolStripMenuItem_Click;
            // 
            // DoingLabel
            // 
            DoingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DoingLabel.AutoSize = true;
            DoingLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DoingLabel.Location = new Point(880, 361);
            DoingLabel.Name = "DoingLabel";
            DoingLabel.Size = new Size(0, 21);
            DoingLabel.TabIndex = 8;
            // 
            // PictRotateButton
            // 
            PictRotateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictRotateButton.Enabled = false;
            PictRotateButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            PictRotateButton.Location = new Point(880, 84);
            PictRotateButton.Margin = new Padding(3, 2, 3, 2);
            PictRotateButton.Name = "PictRotateButton";
            PictRotateButton.Size = new Size(169, 36);
            PictRotateButton.TabIndex = 2;
            PictRotateButton.Text = "画像回転";
            PictRotateButton.UseVisualStyleBackColor = true;
            PictRotateButton.Click += PictRotateButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 517);
            Controls.Add(PictRotateButton);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Button PictRotateButton;
    }
}