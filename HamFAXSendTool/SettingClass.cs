using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamFAXSendTool
{
    internal class SettingClass
    {
        public static string ComPort = string.Empty;
        public static string ComSet = string.Empty;
        public static int ComSpeed = 0;
        public static string SoundCard = string.Empty;

        /// <summary>
        /// 読み取り
        /// </summary>
        public void SettingFileLoad() 
        {
            // 読み出し
            Properties.Settings.Default.Reload();

            // 設定
            ComPort = Properties.Settings.Default.COMPortSetting;
            ComSet = Properties.Settings.Default.COMVerSetting;
            ComSpeed = Properties.Settings.Default.COMSpeedSetting;
            SoundCard = Properties.Settings.Default.SoundCardSetting;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="ComPortName"></param>
        /// <param name="ComSetName"></param>
        /// <param name="ComSpeed"></param>
        /// <param name="SoundCardName"></param>
        public void SettingFileSave(string ComPortName, string ComSetName, int ComSpeedValue, string SoundCardName)
        {
            // 値上書き
            ComPort = ComPortName;
            ComSet = ComSetName;
            ComSpeed = ComSpeedValue;
            SoundCard = SoundCardName;

            // 値を上書き
            Properties.Settings.Default.COMPortSetting = ComPortName;
            Properties.Settings.Default.COMVerSetting = ComSetName;
            Properties.Settings.Default.COMSpeedSetting = ComSpeedValue;
            Properties.Settings.Default.SoundCardSetting = SoundCardName;

            // 保存
            Properties.Settings.Default.Save();
        }
    }
}