using Newtonsoft.Json;

namespace ProcessJSON.VideoFeedGroup
{
    public class Feed
    {
        [JsonProperty("entry")]
        public YoutubeVideo[] Videos { get; set; }
    }
}
