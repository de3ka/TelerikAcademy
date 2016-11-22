using Newtonsoft.Json;

namespace ProcessJSON.MediaGroup
{
    public class Media
    {
        [JsonProperty("media:description")]
        public string Description { get; set; }

        [JsonProperty("media:content")]
        public MediaContent Content { get; set; }

        [JsonProperty("media:community")]
        public MediaCommunity CommunityStats { get; set; }
    }
}
