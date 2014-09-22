namespace UsingXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class XPathOperations
    {
        public static Dictionary<string, int> GetArtistsAndAlbumCount(string path)
        {
            Dictionary<string, int> artists = new Dictionary<string, int>();
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load(path);
            string pathQuery = "/albums/album/artist";

            XmlNodeList albums = catalogue.SelectNodes(pathQuery);
            foreach (XmlNode item in albums)
            {
                var artist = item.InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }

                artists[artist]++;
            }

            return artists;
        }

        public static Dictionary<string, decimal> GetAlbumsWithPricesFrom(string path, int startYear)
        {
            Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load(path);
            string pathQuery = "/albums/album[year<" + startYear + "]";
            
            XmlNodeList albums = catalogue.SelectNodes(pathQuery);
            Console.WriteLine(albums.Count);
            foreach (XmlNode item in albums)
            {
                var name = item.SelectSingleNode("name").InnerText;                
                var price = decimal.Parse(item.SelectSingleNode("price").InnerText);
                prices.Add(name, price);
            }

            return prices;
        }
    }
}
