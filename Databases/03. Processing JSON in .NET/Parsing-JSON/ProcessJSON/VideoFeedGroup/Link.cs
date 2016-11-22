using Newtonsoft.Json;

namespace ProcessJSON.VideoFeedGroup
{
    public class Link
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Url { get; set; }
    }
}