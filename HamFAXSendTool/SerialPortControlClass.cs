using System.Text;
using System.IO.Ports;

namespace HamFAXSendTool
{
    internal class SerialPortControlClass
    {
        /// <summary>
        /// 設定
        /// </summary>
        public SerialPort SerialPort = null;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="ComPost"></param>
        /// <param name="ComVer"></param>
        /// <param name="ComSpeed"></param>
        public SerialPortControlClass(string ComPost, string ComVer, int ComSpeed)
        {
            // 設定
            SerialPort = new SerialPort()
            {
                PortName = ComPost,
                BaudRate = ComSpeed,
                Handshake = Handshake.RequestToSend,
                StopBits = StopBits.One,
                DataBits = 8,
                Parity = Parity.None,
                RtsEnable = (ComVer == "RTS") ? true : false,
                DtrEnable = (ComVer == "DTS") ? true : false,
                Encoding = Encoding.UTF8
            };
        }


        /// <summary>
        /// Open
        /// </summary>
        public void SerialPortControlOpen()
        {
            // ok
            SerialPort.Open();
        }

        /// <summary>
        /// Close
        /// </summary>
        public void SerialPortControlClose()
        {
            // OK
            SerialPort.Close();
        }
    }
}