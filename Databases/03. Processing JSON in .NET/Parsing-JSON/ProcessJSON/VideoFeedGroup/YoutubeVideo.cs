using Newtonsoft.Json;
using System;
using ProcessJSON.MediaGroup;

namespace ProcessJSON.VideoFeedGroup
{
    public class YoutubeVideo
    {
        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("published")]
        public DateTime PublishedOn { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("author")]
        public Author VideoAuthor { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("media:group")]
        public Media VideoMedia { get; set; }
    }
}
