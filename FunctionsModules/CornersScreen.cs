using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInputLib.Native;
using WindowsInputLib;

namespace WinActiveCorners.FunctionsModules
{
    internal class CornersScreen
    {
        private static readonly bool[] _activeCorners = { false, false, false, false };

        public static void СheckTopLeftCorners(Point cursorPosition)
        {
            int x = 15;
            int y = 15;

            bool isActiveCorner = (cursorPosition.X <= x && cursorPosition.Y <= y);
            int cornerNum = 0;

            CheckCorners(isActiveCorner, cornerNum);
        }
        public static void СheckTopRightCorners(Point cursorPosition)
        {
            int x = 1905;
            int y = 15;

            bool isActiveCorner = (cursorPosition.X >= x && cursorPosition.Y <= y);
            int cornerNum = 1;

            CheckCorners(isActiveCorner, cornerNum);
        }
        public static void СheckBottomLeftCorners(Point cursorPosition)
        {
            int x = 15;
            int y = 1065;

            bool isActiveCorner = (cursorPosition.X <= x && cursorPosition.Y >= y);
            int cornerNum = 2;

            CheckCorners(isActiveCorner, cornerNum);
        }
        public static void СheckBottomRightCorners(Point cursorPosition)
        {
            int x = 1915;
            int y = 1075;

            bool isActiveCorner = (cursorPosition.X >= x && cursorPosition.Y >= y);
            int cornerNum = 3;

            CheckCorners(isActiveCorner, cornerNum);
        }

        private static void CheckCorners(bool isActiveCorner, int cornerNum)
        {
            if (isActiveCorner && !_activeCorners[cornerNum])
            {
                InputSimulator inputSimulator = new();
                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LWin);
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.Tab);
                inputSimulator.Keyboard.KeyUp(VirtualKeyCode.LWin);

                Console.WriteLine(_activeCorners[cornerNum]);
                _activeCorners[cornerNum] = true;
            }
            else if (!isActiveCorner)
            {
                _activeCorners[cornerNum] = false;
            }
        }
    }
}
