using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using SixLabors.ImageSharp.Processing;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

namespace net.sictransit.wefax
{
    public class ImageMake
    {
        /// <summary>
        /// バーをつける
        /// </summary>
        /// <param name="ImageFileName"></param>
        /// <returns></returns>
        public string MakeImage(string ImageFileName, string ExeDirPath)
        {
            // ファイル名
            string TempFilePath = System.IO.Path.Combine(ExeDirPath, "TempImage.png");

            // using
            using (Image ImageData = Image.Load<Rgb24>(ImageFileName))
            {
                /*// 収縮する?
                ImageData.Mutate(x =>
                {
                    // 収縮するか
                    x.Resize(ImageData.Width/2, ImageData.Height/2);
                });*/

                // 縦幅
                int OrignW = ImageData.Width;

                // 横幅
                int OrignH = ImageData.Height;

                // 回転&縮小
                ImageData.Mutate(x =>
                {
                    // 回転
                    x.Rotate(RotateMode.Rotate90);

                    // 収縮
                    x.Resize((int)Math.Round(ImageData.Width * 0.95), (int)Math.Round(ImageData.Height * 0.95));
                });

                // using
                using (Image BrackData = new Image<Rgba32>(OrignH, OrignW))
                {
                    // 黒データ
                    BrackData.Mutate(x => x.BackgroundColor(Color.Black));

                    // 乗せる
                    BrackData.Mutate(x => x.DrawImage(ImageData, new Point(OrignW - (int)Math.Round(OrignW * 0.9665), 0), opacity: 1f));

                    // セーブ
                    BrackData.SaveAsPng(TempFilePath);
                }
            }

            // 戻し
            return TempFilePath;
        }
    }
}