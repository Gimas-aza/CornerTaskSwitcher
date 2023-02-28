using CornerTaskSwitcher.Models;
using static CornerTaskSwitcher.Models.Win32;

namespace CornerTaskSwitcher.ApplicationFeatures
{
    internal class ActiveCorners : CornersScreen, IApplicationFeatures
    {
        public static event Action<Point>? OnActiveCornersStorage;

        public static void Initialize()
        {
            Settings settingsActiveCorners = new();
            SetActiveCorners(settingsActiveCorners);
        }

        public static void Update()
        {
            GetCursorPos(out Point cursorPos);
            OnActiveCornersStorage?.Invoke(cursorPos);
        }

        private static void SetActiveCorners(Settings ActiveCorners)
        {

            if (ActiveCorners.TopLeftScreen != "")
            {
                OnActiveCornersStorage += SetTopLeftCorners;
            }
            if (ActiveCorners.TopRightScreen != "")
            {
                OnActiveCornersStorage += SetTopRightCorners;
            }
            if (ActiveCorners.BottomLeftScreen != "")
            {
                OnActiveCornersStorage += SetBottomLeftCorners;
            }
            if (ActiveCorners.BottomRightScreen != "")
            {
                OnActiveCornersStorage += SetBottomRightCorners;
            }
        }
    }
}
