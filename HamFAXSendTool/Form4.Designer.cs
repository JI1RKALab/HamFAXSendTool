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
            SelectPageComboBox.FormattingEnabled = true;
            SelectPageComboBox.Location = new Point(528, 234);
            SelectPageComboBox.Name = "SelectPageComboBox";
            SelectPageComboBox.Size = new Size(200, 28);
            SelectPageComboBox.TabIndex = 1;
            SelectPageComboBox.SelectedIndexChanged += SelectPageComboBox_SelectedIndexChanged;
            // 
            // SelectButton
            // 
            SelectButton.Location = new Point(528, 662);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(200, 79);
            SelectButton.TabIndex = 2;
            SelectButton.Text = "button1";
            SelectButton.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 753);
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
        }

        #endregion

        private PictureBox PDFPictureBox;
        private ComboBox SelectPageComboBox;
        private Button SelectButton;
    }
}