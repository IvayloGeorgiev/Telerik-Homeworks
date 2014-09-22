namespace H16JsonWithNet
{
    using System;
    using Newtonsoft.Json;

    public class Item
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Category { get; set; }

        [JsonProperty("pubDate")]
        public DateTime Published { get; set; }
    }
}