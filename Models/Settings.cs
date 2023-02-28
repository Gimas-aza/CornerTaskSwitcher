namespace CornerTaskSwitcher.Models
{
    public class Settings
    {
        [Newtonsoft.Json.JsonProperty("TopLeftScreen")]
        public string TopLeftScreen { get; }

        [Newtonsoft.Json.JsonProperty("TopRightScreen")]
        public string TopRightScreen { get; }

        [Newtonsoft.Json.JsonProperty("BottomLeftScreen")]
        public string BottomLeftScreen { get; }

        [Newtonsoft.Json.JsonProperty("BottomRightScreen")]
        public string BottomRightScreen { get; }

        public Settings(string nameJsonFile = "Settings.txt")
        {

            string path = Path.Combine(Environment.CurrentDirectory, nameJsonFile);
            string json = File.ReadAllText(path);
            Settings? parserJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(json);

            if (parserJson != null)
            {
                this.TopLeftScreen = parserJson.TopLeftScreen;
                this.TopRightScreen = parserJson.TopRightScreen;
                this.BottomLeftScreen = parserJson.BottomLeftScreen;
                this.BottomRightScreen = parserJson.BottomRightScreen;
            }
            else
                throw new Exception($"В файле {nameJsonFile} нет необходимых данных для корректной работы");
        }
    }
}

