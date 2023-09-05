using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HamFAXSendTool.Properties
{
    internal class CommonProcessClass
    {
        /// <summary>
        /// 削除
        /// </summary>
        public void DeleteFAXFile()
        {
            // 判定
            if (string.IsNullOrWhiteSpace(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav")))
            {
                // OK
                Console.WriteLine("OK");
            }
            else
            {
                // 消す
                if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav")))
                {
                    // OK
                    File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FAXSignal.wav"));
                }
                else
                {
                    // OK
                    Console.Write("OK");
                }
            }
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
    }
}