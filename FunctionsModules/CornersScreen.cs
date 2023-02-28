using WindowsInputLib.Native;
using WindowsInputLib;
using static CornerTaskSwitcher.Models.Win32;

namespace CornerTaskSwitcher.FunctionsModules
{
    internal class CornersScreen
    {
        private static readonly bool[] _activeCorners = { false, false, false, false };

        public static void SetTopLeftCorners(Point cursorPosition)
        {
            int x = 15;
            int y = 15;

            bool isActiveCorner = (cursorPosition.X <= x && cursorPosition.Y <= y);
            int cornerNum = 0;

            SetCorners(isActiveCorner, cornerNum);
        }
        public static void SetTopRightCorners(Point cursorPosition)
        {
            int x = 1905;
            int y = 15;

            bool isActiveCorner = (cursorPosition.X >= x && cursorPosition.Y <= y);
            int cornerNum = 1;

            SetCorners(isActiveCorner, cornerNum);
        }
        public static void SetBottomLeftCorners(Point cursorPosition)
        {
            int x = 15;
            int y = 1065;

            bool isActiveCorner = (cursorPosition.X <= x && cursorPosition.Y >= y);
            int cornerNum = 2;

            SetCorners(isActiveCorner, cornerNum);
        }
        public static void SetBottomRightCorners(Point cursorPosition)
        {
            int x = 1915;
            int y = 1075;

            bool isActiveCorner = (cursorPosition.X >= x && cursorPosition.Y >= y);
            int cornerNum = 3;

            SetCorners(isActiveCorner, cornerNum);
        }

        private static void SetCorners(bool isActiveCorner, int cornerNum)
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
