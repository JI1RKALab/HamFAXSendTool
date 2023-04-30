namespace HamFAXSendTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PictSelectButton_Click(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            PictSelectButton.Enabled = false;
            WAVEBbutton.Enabled = false;
            SendButton.Enabled = false;
            StopButton.Enabled = true;
            StopButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            PictSelectButton.Enabled = true;
            WAVEBbutton.Enabled = true;
            SendButton.Enabled = true;
            StopButton.Enabled = false;
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            // •Â‚¶‚é
            this.Close();
        }

        private void ComPoatSettingStripMenu_Click(object sender, EventArgs e)
        {
            Form2 n = new();
            n.ShowDialog();
        }
    }
}