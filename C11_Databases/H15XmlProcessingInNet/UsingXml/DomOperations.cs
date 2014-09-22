namespace UsingXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class DomOperations
    {
        public static Dictionary<string, int> GetArtistsAndAlbumCount(string path)
        {
            Dictionary<string, int> artists = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var root = doc.DocumentElement;

            foreach (XmlNode album in root.ChildNodes)
            {
                var artist = album["artist"].InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }

                artists[artist]++;
            }

            return artists;
        }

        public static void DeleteAllAbovePrice(string path, decimal price)
        {
            Dictionary<string, int> artists = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var root = doc.DocumentElement;
            List<XmlNode> toRemove = new List<XmlNode>();
            var children = root.ChildNodes;
            
            foreach (XmlNode album in children)
            {
            
                var albumPrice = decimal.Parse((album["price"].InnerText));                
                if (albumPrice > price)
                {
                    toRemove.Add(album);
                }
            }

            foreach (var node in toRemove)
            {
                root.RemoveChild(node);
            }

            doc.Save(path);
        }
    }
}
