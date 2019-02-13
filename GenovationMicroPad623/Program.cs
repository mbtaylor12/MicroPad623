using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GenovationMicroPad623
{
    class Program
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_F5 = 0x74;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        static void Main(string[] args)
        {
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 1200;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.DtrEnable = true;
            port.RtsEnable = true;

            port.Open();

            while (true)
            {
                doKeystroke(port.ReadChar());
            }

        }

        private static void doKeystroke(int input)
        {
            if (input == 95)
                SendKeys.SendWait("0");
            else if(input == 80)
                SendKeys.SendWait("1");
            else if (input == 81)
                SendKeys.SendWait("2");
            else if (input == 82)
                SendKeys.SendWait("3");
            else if (input == 83)
                SendKeys.SendWait("4");
            else if (input == 84)
                SendKeys.SendWait("5");
            else if (input == 85)
                SendKeys.SendWait("6");
            else if (input == 86)
                SendKeys.SendWait("7");
            else if (input == 87)
                SendKeys.SendWait("8");
            else if (input == 88)
                SendKeys.SendWait("9");
            else if (input == 90)
                SendKeys.SendWait("/");
            else if (input == 91)
                SendKeys.SendWait("*");
            else if (input == 92)
                SendKeys.SendWait("-");
            else if (input == 93)
                SendKeys.SendWait("+");
            else if (input == 116)
                SendKeys.SendWait("{Enter}");

        }
    }
}
