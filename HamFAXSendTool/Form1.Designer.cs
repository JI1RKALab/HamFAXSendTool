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
            pictureBox1 = new PictureBox();
            PictSelectButton = new Button();
            SendButton = new Button();
            StopButton = new Button();
            EndButton = new Button();
            StatusTitleLable = new Label();
            IOCComboBox = new ComboBox();
            IOCTitleLable = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(745, 487);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PictSelectButton
            // 
            PictSelectButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            PictSelectButton.Location = new Point(779, 12);
            PictSelectButton.Name = "PictSelectButton";
            PictSelectButton.Size = new Size(193, 48);
            PictSelectButton.TabIndex = 1;
            PictSelectButton.Text = "画像選択";
            PictSelectButton.UseVisualStyleBackColor = true;
            PictSelectButton.Click += PictSelectButton_Click;
            // 
            // SendButton
            // 
            SendButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SendButton.Location = new Point(779, 186);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(193, 48);
            SendButton.TabIndex = 2;
            SendButton.Text = "送信";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // StopButton
            // 
            StopButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            StopButton.Location = new Point(779, 373);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(193, 48);
            StopButton.TabIndex = 3;
            StopButton.Text = "停止";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // EndButton
            // 
            EndButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            EndButton.Location = new Point(779, 451);
            EndButton.Name = "EndButton";
            EndButton.Size = new Size(193, 48);
            EndButton.TabIndex = 4;
            EndButton.Text = "終了";
            EndButton.UseVisualStyleBackColor = true;
            EndButton.Click += EndButton_Click;
            // 
            // StatusTitleLable
            // 
            StatusTitleLable.AutoSize = true;
            StatusTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTitleLable.Location = new Point(779, 261);
            StatusTitleLable.Name = "StatusTitleLable";
            StatusTitleLable.Size = new Size(92, 28);
            StatusTitleLable.TabIndex = 5;
            StatusTitleLable.Text = "スタータス:";
            // 
            // IOCComboBox
            // 
            IOCComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IOCComboBox.FormattingEnabled = true;
            IOCComboBox.Items.AddRange(new object[] { "288(アマチュア無線モード)", "576(業務局モード)" });
            IOCComboBox.Location = new Point(779, 121);
            IOCComboBox.Name = "IOCComboBox";
            IOCComboBox.Size = new Size(193, 28);
            IOCComboBox.TabIndex = 6;
            // 
            // IOCTitleLable
            // 
            IOCTitleLable.AutoSize = true;
            IOCTitleLable.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            IOCTitleLable.Location = new Point(779, 78);
            IOCTitleLable.Name = "IOCTitleLable";
            IOCTitleLable.Size = new Size(97, 28);
            IOCTitleLable.TabIndex = 7;
            IOCTitleLable.Text = "協動係数:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 511);
            Controls.Add(IOCTitleLable);
            Controls.Add(IOCComboBox);
            Controls.Add(StatusTitleLable);
            Controls.Add(EndButton);
            Controls.Add(StopButton);
            Controls.Add(SendButton);
            Controls.Add(PictSelectButton);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button PictSelectButton;
        private Button SendButton;
        private Button StopButton;
        private Button EndButton;
        private Label StatusTitleLable;
        private ComboBox IOCComboBox;
        private Label IOCTitleLable;
    }
}