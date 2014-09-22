namespace UsingXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class XmlWithLinq
    {
        public static IEnumerable<string> GetAllSongs(string path)
        {
            List<string> songs = new List<string>();
            XDocument doc = XDocument.Load(path);
            foreach (var item in doc.Descendants("song"))
            {
                songs.Add(item.Attribute("title").Value);
            }            

            return songs;
        }

        public static void CreateXmlPersons(string source, string output)
        {
            StreamReader reader = new StreamReader(source);
            XElement root = new XElement("people");
            using (reader)
            {
                string line = string.Empty;
                while((line = reader.ReadLine()) != null)
                {
                    var person = new XElement("person", 
                        new XElement("name", line),
                        new XElement("address", reader.ReadLine()),
                        new XElement("phone-number", reader.ReadLine())
                        );       
                    root.Add(person);
                }
            }

            root.Save(output);
        }

        public static void CreateXmlFromDirectory(string path, string output)
        {
            var root = new XElement("dir");
            AddDirectory(path, root);
            root.Save(output);
        }

        public static Dictionary<string, decimal> GetAlbumsWithPricesFrom(string path, int startYear)
        {
            Dictionary<string, decimal> prices = new Dictionary<string, decimal>();         
            XDocument doc = XDocument.Load(path);

            var albumstAfter = doc.Descendants("album")
                .Where(a => int.Parse(a.Element("year").Value) <= startYear)
                .Select(a =>
                    new
                    {
                        Name = a.Element("name").Value,
                        Price = decimal.Parse(a.Element("price").Value)
                    }
                );

            foreach (var item in albumstAfter)
            {
                prices.Add(item.Name, item.Price);
            }            

            return prices;
        }

        private static void AddDirectory(string directory, XElement element)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);
            
            var directoryName = directory.Split(new char[] { '\\' });
            element.Add(new XAttribute("name", directoryName[directoryName.Length - 1]));            

            foreach (var subDirectory in subDirectories)
            {
                var sub = new XElement("dir");
                AddDirectory(subDirectory, sub);
                element.Add(sub);
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Split(new char[] { '\\' });
                element.Add(new XElement("file", fileName[fileName.Length - 1]));                
            }            
        }        
    }
}
