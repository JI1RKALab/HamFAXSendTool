namespace HamFAXSendTool
{
    partial class Form3
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
            CallSignInputTextBox = new TextBox();
            SettingButton = new Button();
            CallSineLabel = new Label();
            SuspendLayout();
            // 
            // CallSignInputTextBox
            // 
            CallSignInputTextBox.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            CallSignInputTextBox.Location = new Point(12, 75);
            CallSignInputTextBox.Name = "CallSignInputTextBox";
            CallSignInputTextBox.Size = new Size(251, 32);
            CallSignInputTextBox.TabIndex = 1;
            CallSignInputTextBox.KeyPress += CallSignInputTextBox_KeyPress;
            // 
            // SettingButton
            // 
            SettingButton.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            SettingButton.Location = new Point(36, 139);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(193, 48);
            SettingButton.TabIndex = 2;
            SettingButton.Text = "設定";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // CallSineLabel
            // 
            CallSineLabel.AutoSize = true;
            CallSineLabel.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            CallSineLabel.Location = new Point(58, 24);
            CallSineLabel.Name = "CallSineLabel";
            CallSineLabel.Size = new Size(137, 25);
            CallSineLabel.TabIndex = 0;
            CallSineLabel.Text = "コールサイン入力";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 224);
            Controls.Add(CallSineLabel);
            Controls.Add(SettingButton);
            Controls.Add(CallSignInputTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            Text = "コールサイン設定";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CallSignInputTextBox;
        private Button SettingButton;
        private Label CallSineLabel;
    }
}