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

                    // テキストボックス
                    JCCJCGTextBox.Enabled = true;

                    // 取り敢えず1ページ
                    JCCJCGSelectComboBox.SelectedIndex = 0;

                    // ボタン
                    JCCJCGSelectComboBox.Enabled = true;

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

            // コールサイン
            SendCallSignSet(!string.IsNullOrEmpty(JCCJCGTextBox.Text));
        }

        /// <summary>
        /// JCC/JCG入力テキストボックス退去後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JCCJCGTextBox_Leave(object sender, EventArgs e)
        {
            // クリア
            PDFPictureBox.Image.Dispose();

            // テキストボックス
            SendCallSignSet(!string.IsNullOrEmpty(JCCJCGTextBox.Text));
        }

        /// <summary>
        /// コールサインプロット
        /// </summary>
        /// <param name="InputJCCJCGFlag"></param>
        private void SendCallSignSet(bool InputJCCJCGFlag)
        {
            // OK
            PDFPictureBox.Image.Dispose();

            // 画像設定
            PDFPictureBox.Image = new Bitmap(FilePathList[SelectPageComboBox.SelectedIndex]);

            // 現状の画像データをロード
            Bitmap NewBitmMap = new(PDFPictureBox.Image);

            // 新しいグラフィックとして定義
            Graphics TempGraphics = Graphics.FromImage(NewBitmMap);

            // テキストの色を定義する
            Brush TextBrush = new SolidBrush(Color.Black);

            // テキストのフォントを定義する
            Font ArialFont = new("Arial", 15, FontStyle.Regular);

            // 表示するテキスト
            string InputText = $"DE {SettingClass.UserCallSign}" + (InputJCCJCGFlag ? $" {JCCJCGSelectComboBox.Text}:{JCCJCGTextBox.Text}" : string.Empty);

            // 長方形の定義
            Rectangle TextRectangle = new(10, 10, 450, 100);

            // 画像上にテキストを描画します
            TempGraphics.DrawString(InputText, ArialFont, TextBrush, TextRectangle);

            // クリア
            PDFPictureBox.Image.Dispose();

            // 設定
            PDFPictureBox.Image = NewBitmMap;
        }

        /// <summary>
        /// JCC/JCG選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JCCJCGSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // OK
            JCCJCGLabel.Text = ((ComboBox)sender).Text + "コード入力";

            // リセット
            SendCallSignSet(false);
        }

        /// <summary>
        /// 数値のみ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JCCJCGTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                //OK
                e.Handled = true;
            }
            else
            {
                // NG
                Console.WriteLine(string.Empty);
            }
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
            PDFPictureBox.Image.Save(CopyPath);

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