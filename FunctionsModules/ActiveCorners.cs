namespace CornerTaskSwitcher.FunctionsModules
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

        public static void SetActiveCorners(Models.Settings ActiveCorners)
        {

            if (ActiveCorners.TopLeftScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.SetTopLeftCorners;
            }
            if (ActiveCorners.TopRightScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.SetTopRightCorners;
            }
            if (ActiveCorners.BottomLeftScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.SetBottomLeftCorners;
            }
            if (ActiveCorners.BottomRightScreen != "")
            {
                Program.OnHotCornerStorage += CornersScreen.SetBottomRightCorners;
            }
        }
    }
}
