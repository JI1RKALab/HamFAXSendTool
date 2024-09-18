using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamFAXSendTool
{
    public partial class Form4 : Form
    {
        readonly string PDFPath = string.Empty;

        public Form4(string PDFPath)
        {
            InitializeComponent();
            this.PDFPath = PDFPath;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // PDFを画像にする
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ベースファイルを削除する
        }

        private void SelectPageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
