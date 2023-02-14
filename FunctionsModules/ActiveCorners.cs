using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MasterViewWindow;

namespace WinActiveCorners.FunctionsModules
{
    internal class ActiveCorners
    {
        public static Models.Settings GetParserJson(string nameJsonFile = "Settings.txt")
        {

            var path = Path.Combine(Environment.CurrentDirectory, nameJsonFile);
            string json = File.ReadAllText(path);
            var ParserJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Settings>(json);

            if (ParserJson != null)
            {
                return ParserJson;
            }
            else
            {
                throw new Exception($"В файле {nameJsonFile} нет необходимых данных для корректной работы");
            }
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        public static void SetActiveCorners(Models.Settings ActiveCorners)
        {

            if (ActiveCorners.TopLeftScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.СheckTopLeftCorners;
            }
            if (ActiveCorners.TopRightScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.СheckTopRightCorners;
            }
            if (ActiveCorners.BottomLeftScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.СheckBottomLeftCorners;
            }
            if (ActiveCorners.BottomRightScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.СheckBottomRightCorners;
            }
        }
    }
}
