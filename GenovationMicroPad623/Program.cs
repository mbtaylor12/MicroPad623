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

            //Parse through mappings text file and assign dictionary values
            string[] keys = System.IO.File.ReadAllLines("Mappings.txt");

            foreach (String key in keys)
            {
                int byteValue = Int32.Parse(key.Split('=')[0]);
                String keyValue = key.Split('=')[1];

                mappings.Add(byteValue, keyValue);
            }

            return mappings;
        }
    }
}
