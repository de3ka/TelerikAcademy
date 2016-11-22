using Newtonsoft.Json;

namespace ProcessJSON.MediaGroup
{
    public class MediaRating
    {
        [JsonProperty("@average")]
        public double Average { get; set; }
    }
}
