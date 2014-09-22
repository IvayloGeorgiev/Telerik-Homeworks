namespace H16JsonWithNet
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    class MainEntry
    {
        private static string RssFeedNet = "http://forums.academy.telerik.com/feed/qa.rss ";
        private static string RssFeedLocal = "../../rss.xml";
        private static string JsonLocal = "../../rss.json";
        private static string HtmlLocal = "../../questions.html";

        static void Main(string[] args)
        {
            //Task 2
            using (var client = new WebClient())
            {
                client.DownloadFile(RssFeedNet, RssFeedLocal);
            }

            //Task 3
            var xml = XDocument.Load(RssFeedLocal);
            var json = JsonConvert.SerializeXNode(xml, Formatting.Indented);
            File.WriteAllText(JsonLocal, json);

            //Task 4
            //I think it means to only select title that don't have answered in them.
            var jsonObj = JObject.Parse(json);
            var question = jsonObj["rss"]["channel"]["item"].Where(x => !((string)x["title"]).Contains("Answered"));
            var title = question.Select(x => new { Title = x["title"] });
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(string.Join("\n", title));
            Console.WriteLine("\n------------------------\n");

            //Task 5                        
            var jsonForPocos = new JArray(question).ToString();
            var pocos = JsonConvert.DeserializeObject<Item[]>(jsonForPocos);            

            //Task 6
            var html = ParsePocoToHtml.ParseToHtml(pocos);
            File.WriteAllText(HtmlLocal, html);
        }
    }
}
