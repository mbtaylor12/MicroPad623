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
            IDictionary<int, String> mappings = CreateMappings();

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
                SendKeys.SendWait(mappings[port.ReadChar()]);
            }

        }

        /*
         * CreateMappings() - Creates mappings from bytes to a key representation.
         * @return - IDictonary where the key is the byte input and the value is the keyboard key.
         */
        private static IDictionary<int, String> CreateMappings()
        {
            IDictionary<int, String> mappings = new Dictionary<int, String>();

            mappings.Add(95, "0");
            mappings.Add(80, "1");
            mappings.Add(81, "2");
            mappings.Add(82, "3");
            mappings.Add(83, "4");
            mappings.Add(84, "5");
            mappings.Add(85, "6");
            mappings.Add(86, "7");
            mappings.Add(87, "8");
            mappings.Add(88, "9");
            mappings.Add(90, "/");
            mappings.Add(91, "*");
            mappings.Add(92, "-");
            mappings.Add(93, "{+}");
            mappings.Add(94, ".");
            mappings.Add(116, "{Enter}");

            return mappings;
        }
    }
}
