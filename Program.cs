using CornerTaskSwitcher.ApplicationFeatures;

// rename on CornerDesktopSwitcher
namespace CornerTaskSwitcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActiveCorners.Initialize();
            TaskView.Initialize();

            while (true)
            {
                ActiveCorners.Update();

                TaskView.Update();

                Thread.Sleep(300);
            }
        }
    }
}