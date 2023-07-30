namespace HamFAXSendTool
{
    internal class SettingClass
    {
        /// <summary>
        /// COMボード
        /// </summary>
        public static string ComPort = string.Empty;

        /// <summary>
        /// DTR/RTS
        /// </summary>
        public static string ComSet = string.Empty;

        /// <summary>
        /// シリアルスピード
        /// </summary>
        public static int ComSpeed = 0;

        /// <summary>
        /// サウンドボード設定
        /// </summary>
        public static string SoundCard = string.Empty;

        /// <summary>
        /// コールサイン設定
        /// </summary>
        public static string UserCallSign = string.Empty;

        /// <summary>
        /// IOC設定
        /// </summary>
        public static int IOCSettingValue = new int();

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
            UserCallSign = Properties.Settings.Default.UserCallSignSetting;
            IOCSettingValue = Properties.Settings.Default.IOCSettingValue;
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

        /// <summary>
        /// コールサイン設定
        /// </summary>
        /// <param name="InputUserCallCallSign"></param>
        public void CallSignSettingFileSave(string InputUserCallCallSign)
        {
            // 値上書き
            UserCallSign = InputUserCallCallSign;

            // 値を上書き
            Properties.Settings.Default.UserCallSignSetting = UserCallSign;

            // 保存
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// IOC設定
        /// </summary>
        /// <param name="IOCValueSave"></param>
        public void IOCValueSave(string IOCValueSave)
        {
            // 選択
            switch (IOCValueSave)
            {
                // HAM1
                case "288(アマチュア無線モード1)":
                    Properties.Settings.Default.IOCSettingValue = 288;
                    break;

                // HAM2
                case "288/576(アマチュア無線モード2)":
                    Properties.Settings.Default.IOCSettingValue = 288576;
                    break;

                // OK
                case "576(業務局モード)":
                default:
                    Properties.Settings.Default.IOCSettingValue = 576;
                    break;
            }

            // SAVE
            Properties.Settings.Default.Save();
        }
    }
}