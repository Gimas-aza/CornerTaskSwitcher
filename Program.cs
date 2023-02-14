using WinActiveCorners.FunctionsModules;
using WinFunctionsOverview.FunctionsModules;

namespace MasterViewWindow
{
    internal class Program
    {
        public static event Action<Point>? OnHotCornerStorage;

        static void Main(string[] args)
        {
            SetActiveCornersInScreen();

            while (true)
            {
                ActiveCorners.GetCursorPos(out Point cursorPos);
                OnHotCornerStorage?.Invoke(cursorPos);

                MenuOverview.TrySwitchDesktops();

                Thread.Sleep(300);
                Console.Clear();
            }
        }

        private static void SetActiveCornersInScreen()
        {
            var settingsActiveCorners = ActiveCorners.GetParserJson();
            ActiveCorners.SetActiveCorners(settingsActiveCorners);
        }
    }
}