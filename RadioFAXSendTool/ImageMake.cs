using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using SixLabors.ImageSharp.Processing;

namespace net.sictransit.wefax
{
    public class ImageMake
    {
        /// <summary>
        /// バーをつける
        /// </summary>
        /// <param name="ImageFileName"></param>
        /// <returns></returns>
        public string MakeImage(string ImageFileName,string ExeDirPath)
        {
            // ファイル名
            string TempFilePath = System.IO.Path.Combine(ExeDirPath, "TempImage.png");

            // using
            using (Image ImageData = Image.Load<Rgb24>(ImageFileName))
            {
                // using
                using (Image BrackData = new Image<Rgba32>((int)Math.Round(ImageData.Width * 1.045), ImageData.Height))
                {
                    // 黒データ
                    BrackData.Mutate(x => x.BackgroundColor(SixLabors.ImageSharp.Color.Black));
                    BrackData.Mutate(x => x.DrawImage(ImageData, new SixLabors.ImageSharp.Point((int)Math.Round(ImageData.Width * 1.045) - ImageData.Width, 0), opacity: 1f));
                    BrackData.SaveAsPng(TempFilePath);

                }
            }

            // 戻し
            return TempFilePath;
        }
    }
}