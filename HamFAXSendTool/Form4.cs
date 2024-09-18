using Spire.Pdf;
using System.Drawing.Imaging;

namespace HamFAXSendTool
{
    public partial class Form4 : Form
    {
        /// <summary>
        /// ディレクトリ入れる
        /// </summary>
        string DirPrth = string.Empty;

        /// <summary>
        /// リスト
        /// </summary>
        List<string> FilePathList = new();

        /// <summary>
        /// PDFファイルリスト
        /// </summary>
        readonly string PDFPath = string.Empty;

        /// <summary>
        /// 選択したURLパス
        /// </summary>
        public string SelectImagePath = string.Empty;

        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="PDFPath"></param>
        public Form4(string PDFPath)
        {
            // 処理
            InitializeComponent();

            // URLを設定
            this.PDFPath = PDFPath;
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form4_Load(object sender, EventArgs e)
        {
            // 非同期読み込み
            await Task.Run(() =>
            {
                // PDFを画像にする為のディレクトリ生成
                DirPrth = Path.Combine(Directory.GetParent(Application.ExecutablePath)!.FullName, "TempPDFToImageDir");

                // Dir生成
                Directory.CreateDirectory(DirPrth);

                // 読み込み
                PdfDocument PDFDoc = new();

                // 読み込み
                PDFDoc.LoadFromFile(this.PDFPath);

                // ストリームデータ
                Stream StreamData = null!;

                // パス
                string TempFilePath = string.Empty;

                // イメージデータ
                Image ImageData = null!;

                // ループ
                for (int i = 0; i < PDFDoc.Pages.Count; i++)
                {
                    //すべてのページを画像に変換し、画像のDpiを設定する。
                    StreamData = PDFDoc.SaveAsImage(i);

                    //画像をPNG形式で指定フォルダに保存 
                    TempFilePath = string.Format("ToImage-{0}.png", i);

                    // コンバート
                    ImageData = Image.FromStream(StreamData);

                    // Save
                    ImageData.Save(Path.Combine(DirPrth, TempFilePath), ImageFormat.Png);

                    // リストにAdd
                    FilePathList.Add(Path.Combine(DirPrth, TempFilePath));

                    // メインに戻す
                    this.Invoke(new Action(() =>
                    {
                        // コンボボックスにAdd
                        SelectPageComboBox.Items.Add($"{i + 1}ページ目");
                    }));
                }

                // メインに戻す
                Invoke(new Action(() =>
                {
                    // 取り敢えず1ページ目をプロット
                    PDFPictureBox.Image = new Bitmap(FilePathList[0]);

                    // サイズモードをズームに設定
                    PDFPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // 取り敢えず1ページ
                    SelectPageComboBox.SelectedIndex = 0;

                    // コンボボックスの操作
                    SelectPageComboBox.Enabled = SelectPageComboBox.Items.Count > 1 ? true : false;

                    // 消し
                    PreparingLabel.Visible = false;

                    // ボタン
                    SelectButton.Enabled = true;
                }));
            });
        }

        /// <summary>
        /// 選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // OK
            PDFPictureBox.Image.Dispose();

            // 画像設定
            PDFPictureBox.Image = new Bitmap(FilePathList[((ComboBox)sender).SelectedIndex]);
        }

        /// <summary>
        /// クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, EventArgs e)
        {
            // Path生成
            string CopyPath = Path.Combine(Directory.GetParent(DirPrth)!.FullName, $"SendPictPDF_{DateTime.Now.ToString("yyyyMMddHHmmss")}.png");

            // コピー
            File.Copy(FilePathList[SelectPageComboBox.SelectedIndex], CopyPath);

            // 設定
            SelectImagePath = CopyPath;

            // 閉じる
            Close();
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            // クリア
            PDFPictureBox.Image.Dispose();

            // フォルダ削除
            Directory.Delete(DirPrth, true);
        }
    }
}