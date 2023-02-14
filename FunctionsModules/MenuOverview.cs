using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInputLib;

namespace WinFunctionsOverview.FunctionsModules
{
    internal class MenuOverview
    {
        public static void TrySwitchDesktops()
        {
                CheckMouseWheel();
        }

        private static void CheckMouseWheel()
        {
            uint mouseData = (uint)GetMessageExtraInfo().ToInt32();
            int mouseWheelDelta = (short)(mouseData >> 16);

            Console.WriteLine(mouseData);

            if (mouseWheelDelta > 0)
            {
                Console.WriteLine("Mouse wheel scrolled up");
            }
            else if (mouseWheelDelta < 0)
            {
                Console.WriteLine("Mouse wheel scrolled down");
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();
    }
}
