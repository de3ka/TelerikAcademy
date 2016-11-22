using Newtonsoft.Json;

namespace ProcessJSON.MediaGroup
{
    public class MediaStatistics
    {
        [JsonProperty("@views")]
        public int ViewsCount { get; set; }
    }
}
