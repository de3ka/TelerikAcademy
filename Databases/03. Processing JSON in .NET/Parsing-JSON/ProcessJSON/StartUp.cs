using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml;
using ProcessJSON.VideoFeedGroup;

namespace ProcessJSON
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var url = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var path = "../../video-feed.xml";
            Console.OutputEncoding = Encoding.UTF8;

            DownloadFile(url, path);
            
            var jsonString = ParseTheXmlToJson(path);
            
            LinqToJsonPrintTitles(jsonString);
            
            YoutubeFeed videos = ParseJsonToVideosPOCO(jsonString);
            
            CreateHtmlFromPoco(videos);
        }

        private static void CreateHtmlFromPoco(YoutubeFeed videos)
        {
            Console.WriteLine("\n----------TASK6----------");

            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head><title>Telerik Academy Videos</title></head>");
            html.AppendLine("<body>");
            html.AppendLine("<meta charset=\"ISO - 8859 - 1\">");

            foreach (var video in videos.Feed.Videos)
            {
                html.AppendLine("<div>");
                html.AppendLine($"<div><a href=\"{video.Link.Url}\">{video.Title}</a></div>");
                html.AppendLine($"<iframe src=\"{ video.VideoMedia.Content.ContentUrl}\">");
                html.AppendLine("</iframe>");
                html.AppendLine($"<div>Published by:<a href=\"{video.VideoAuthor.Uri}\">{video.VideoAuthor.Name}</a></div>");
                html.AppendLine($"<div>Published on:<strong> {video.PublishedOn.ToShortDateString()} {video.PublishedOn.ToShortTimeString()}</strong></div>");
                html.AppendLine($"<div>Updated on:<strong> {video.Updated.ToShortDateString()} {video.Updated.ToShortTimeString()}</strong></div>");
                html.AppendLine($"<div>Views:<strong> {video.VideoMedia.CommunityStats.Statistics.ViewsCount}</strong></div>");
                html.AppendLine($"<div>Rating:<strong> { video.VideoMedia.CommunityStats.Rating.Average}</strong></div>");
                html.AppendLine($"<p>Description:{ video.VideoMedia.Description}</p>");
                html.AppendLine("</div>");
            }

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            File.WriteAllText("../../video-feed.html", html.ToString(), Encoding.UTF8);

            Console.WriteLine("video-feed.html created. Go to the root directory and open file.");
        }

        private static YoutubeFeed ParseJsonToVideosPOCO(string jsonString)
        {

            Console.WriteLine("\n----------TASK5----------");
            var youtubeFeed = JsonConvert.DeserializeObject<YoutubeFeed>(jsonString);
            Console.WriteLine("JSON is parsed to POCO");
            return youtubeFeed;
        }

        private static void LinqToJsonPrintTitles(string jsonString)
        {
            Console.WriteLine("\n----------TASK4----------");
            Console.WriteLine("Titles printed with LINQ: ");
            Console.WriteLine();

            var jsonObj = JObject.Parse(jsonString);

            var jsObjVideos = jsonObj["feed"]["entry"];

            var titles = jsObjVideos
                    .Select(x => x["title"].Value<string>());

            foreach (var title in titles)
            {
                Console.WriteLine($"Title: {title}");
            }
        }

        private static string ParseTheXmlToJson(string path)
        {
            Console.WriteLine("\n----------TASK3----------");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            var root = doc.DocumentElement;

            string jsonFromXml = JsonConvert.SerializeXmlNode(root, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine("Json parsed from XML. See root directory for file 'video-feed.xml'.");
            return jsonFromXml;
        }

        private static void DownloadFile(string url, string pathToSave)
        {
            Console.WriteLine("----------TASK1-TASK2----------");
            WebClient client = new WebClient();

            client.DownloadFile(url, pathToSave);
            Console.WriteLine("File is now downloaded.");
        }
    }
}