namespace HamFAXSendTool
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            PDFPictureBox = new PictureBox();
            SelectPageComboBox = new ComboBox();
            SelectButton = new Button();
            PreparingLabel = new Label();
            PageSelectLabel = new Label();
            JCCJCGLabel = new Label();
            JCCJCGTextBox = new TextBox();
            JCCJCGSelectLabel = new Label();
            JCCJCGSelectComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)PDFPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PDFPictureBox
            // 
            PDFPictureBox.Location = new Point(12, 12);
            PDFPictureBox.Name = "PDFPictureBox";
            PDFPictureBox.Size = new Size(510, 729);
            PDFPictureBox.TabIndex = 0;
            PDFPictureBox.TabStop = false;
            // 
            // SelectPageComboBox
            // 
            SelectPageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectPageComboBox.Enabled = false;
            SelectPageComboBox.FormattingEnabled = true;
            SelectPageComboBox.Location = new Point(528, 234);
            SelectPageComboBox.Name = "SelectPageComboBox";
            SelectPageComboBox.Size = new Size(200, 28);
            SelectPageComboBox.TabIndex = 3;
            SelectPageComboBox.SelectedIndexChanged += SelectPageComboBox_SelectedIndexChanged;
            // 
            // SelectButton
            // 
            SelectButton.Enabled = false;
            SelectButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold);
            SelectButton.Location = new Point(528, 662);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(200, 79);
            SelectButton.TabIndex = 8;
            SelectButton.Text = "選択";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // PreparingLabel
            // 
            PreparingLabel.AutoSize = true;
            PreparingLabel.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold);
            PreparingLabel.Location = new Point(524, 85);
            PreparingLabel.Name = "PreparingLabel";
            PreparingLabel.Size = new Size(218, 37);
            PreparingLabel.TabIndex = 1;
            PreparingLabel.Text = "PDF読み込み中...";
            // 
            // PageSelectLabel
            // 
            PageSelectLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PageSelectLabel.AutoSize = true;
            PageSelectLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            PageSelectLabel.Location = new Point(528, 203);
            PageSelectLabel.Name = "PageSelectLabel";
            PageSelectLabel.Size = new Size(119, 28);
            PageSelectLabel.TabIndex = 2;
            PageSelectLabel.Text = "ページ数選択";
            // 
            // JCCJCGLabel
            // 
            JCCJCGLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            JCCJCGLabel.AutoSize = true;
            JCCJCGLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            JCCJCGLabel.Location = new Point(528, 359);
            JCCJCGLabel.Name = "JCCJCGLabel";
            JCCJCGLabel.Size = new Size(125, 28);
            JCCJCGLabel.TabIndex = 6;
            JCCJCGLabel.Text = "JCCコード入力";
            // 
            // JCCJCGTextBox
            // 
            JCCJCGTextBox.Enabled = false;
            JCCJCGTextBox.ImeMode = ImeMode.Off;
            JCCJCGTextBox.Location = new Point(528, 390);
            JCCJCGTextBox.Name = "JCCJCGTextBox";
            JCCJCGTextBox.Size = new Size(200, 27);
            JCCJCGTextBox.TabIndex = 7;
            JCCJCGTextBox.KeyPress += JCCJCGTextBox_KeyPress;
            JCCJCGTextBox.Leave += JCCJCGTextBox_Leave;
            // 
            // JCCJCGSelectLabel
            // 
            JCCJCGSelectLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            JCCJCGSelectLabel.AutoSize = true;
            JCCJCGSelectLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            JCCJCGSelectLabel.Location = new Point(528, 282);
            JCCJCGSelectLabel.Name = "JCCJCGSelectLabel";
            JCCJCGSelectLabel.Size = new Size(126, 28);
            JCCJCGSelectLabel.TabIndex = 4;
            JCCJCGSelectLabel.Text = "JCC/JCG選択";
            // 
            // JCCJCGSelectComboBox
            // 
            JCCJCGSelectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            JCCJCGSelectComboBox.Enabled = false;
            JCCJCGSelectComboBox.FormattingEnabled = true;
            JCCJCGSelectComboBox.Items.AddRange(new object[] { "JCC", "JCG" });
            JCCJCGSelectComboBox.Location = new Point(528, 313);
            JCCJCGSelectComboBox.Name = "JCCJCGSelectComboBox";
            JCCJCGSelectComboBox.Size = new Size(200, 28);
            JCCJCGSelectComboBox.TabIndex = 5;
            JCCJCGSelectComboBox.SelectedIndexChanged += JCCJCGSelectComboBox_SelectedIndexChanged;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 753);
            Controls.Add(JCCJCGSelectLabel);
            Controls.Add(JCCJCGSelectComboBox);
            Controls.Add(JCCJCGTextBox);
            Controls.Add(JCCJCGLabel);
            Controls.Add(PageSelectLabel);
            Controls.Add(PreparingLabel);
            Controls.Add(SelectButton);
            Controls.Add(SelectPageComboBox);
            Controls.Add(PDFPictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form4";
            Text = "PDF選択フォーム";
            FormClosed += Form4_FormClosed;
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)PDFPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PDFPictureBox;
        private ComboBox SelectPageComboBox;
        private Button SelectButton;
        private Label PreparingLabel;
        private Label PageSelectLabel;
        private Label JCCJCGLabel;
        private TextBox JCCJCGTextBox;
        private Label JCCJCGSelectLabel;
        private ComboBox JCCJCGSelectComboBox;
    }
}