namespace CornerTaskSwitcher.Models
{
    public class Settings
    {
        [Newtonsoft.Json.JsonProperty("TopLeftScreen")]
        public string TopLeftScreen { get; private set; }

        [Newtonsoft.Json.JsonProperty("TopRightScreen")]
        public string TopRightScreen { get; private set; }

        [Newtonsoft.Json.JsonProperty("BottomLeftScreen")]
        public string BottomLeftScreen { get; private set; }

        [Newtonsoft.Json.JsonProperty("BottomRightScreen")]
        public string BottomRightScreen { get; private set; }
    }
}

