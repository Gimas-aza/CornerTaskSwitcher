using CornerTaskSwitcher.FunctionsModules;
using CornerTaskSwitcher.Models;
using static CornerTaskSwitcher.Models.Win32;

namespace CornerTaskSwitcher
{
    internal class Program
    {
        public static event Action<Point>? OnHotCornerStorage;

        static void Main(string[] args)
        {
            SetActiveCornersInScreen();
            TaskView.Initialize();

            while (true)
            {
                GetCursorPos(out Point cursorPos);
                OnHotCornerStorage?.Invoke(cursorPos);

                TaskView.TrySwitchDesktops();

                Thread.Sleep(300);
                Console.Clear();
            }
        }

        private static void SetActiveCornersInScreen()
        {
            Settings settingsActiveCorners = ActiveCorners.GetParserJson();
            ActiveCorners.SetActiveCorners(settingsActiveCorners);
        }
    }
}