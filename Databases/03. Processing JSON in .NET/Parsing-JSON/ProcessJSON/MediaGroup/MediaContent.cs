using Newtonsoft.Json;

namespace ProcessJSON.MediaGroup
{
    public class MediaContent
    {
        [JsonProperty("@url")]
        public string ContentUrl { get; set; }
    }
}
