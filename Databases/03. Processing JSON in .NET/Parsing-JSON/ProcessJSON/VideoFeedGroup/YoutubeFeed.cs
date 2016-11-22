using Newtonsoft.Json;

namespace ProcessJSON.VideoFeedGroup
{
    public class YoutubeFeed
    {
        [JsonProperty("feed")]
        public Feed Feed { get; set; }
    }
}
