using NAudio.Wave;
using net.sictransit.wefax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HamFAXSendTool
{
    internal class CommonProcessClass
    {
        /// <summary>
        /// 削除
        /// </summary>
        public void DeleteFAXFile()
        {
            // 判定
            if (string.IsNullOrWhiteSpace(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "FAXSignal.wav")))
            {
                // OK
                Console.WriteLine("OK");
            }
            else
            {
                // 消す
                if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "FAXSignal.wav")))
                {
                    // OK
                    File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "FAXSignal.wav"));
                }
                else
                {
                    // OK
                    Console.Write("OK");
                }
            }

            // PDFで起こした画像があればそれも消す
            new DirectoryInfo(Directory.GetParent(Application.ExecutablePath)!.FullName).GetFiles("SendPictPDF_*.png",SearchOption.AllDirectories).ToList().ForEach(x => 
            {
                // 削除
                File.Delete(x.FullName);
            });
        }

        /// <summary>
        /// カード選択
        /// </summary>
        /// <returns></returns>
        public int PlaySoundCardIndexNoSelect()
        {
            // INDEX番号を入れておく
            int PlaySoundCardIndexNo = new();

            // サウンドカード取得
            List<DirectSoundDeviceInfo> Capabilities = DirectSoundOut.Devices.ToList();

            // ループ
            for (int i = 0; i < Capabilities.Count(); i++)
            {
                // Add
                if (Capabilities[i].Description == SettingClass.SoundCard)
                {
                    // OK
                    PlaySoundCardIndexNo = i;
                }
                else
                {
                    // Skip
                    continue;
                }
            }

            // 戻し
            return PlaySoundCardIndexNo - 1;
        }

        /// <summary>
        /// FAX停止信号生成
        /// </summary>
        /// <returns></returns>
        public string FAXStopSignalGenerator(int RPMValue)
        {
            // ファイル生成
            string OutputFAXSignalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "FAXStopSignal.wav");

            // 停止信号生成
            new FaxMachine().FAXStopSignalGenerator(OutputFAXSignalPath, RPMValue);

            // 戻し
            return OutputFAXSignalPath;
        }
    }
}