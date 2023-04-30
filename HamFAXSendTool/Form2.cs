using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;

namespace HamFAXSendTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<NAudio.Wave.DirectSoundDeviceInfo> Capabilities = NAudio.Wave.DirectSoundOut.Devices.ToList();
            //List<string> DeviceList = Capabilities.Select(x => x.ModuleName).ToList();

            // ループ
            foreach (string CardName in Capabilities.Select(x => x.Description).ToList())
            {
                // Add
                SoundCardListBox.Items.Add(CardName);
            }
        }

        /// <summary>
        /// ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComTestButton_Click(object sender, EventArgs e)
        {
            if (ComPortListBox.SelectedIndex == -1) 
            {
                MessageBox.Show("COMポートを選択して下さい!", "COMポート未選択エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            } 
            else { }
        }
    }
}
