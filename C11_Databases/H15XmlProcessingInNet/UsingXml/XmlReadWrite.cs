namespace UsingXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class XmlReadWrite
    {
        public static IEnumerable<string> ExtractSongTitles(string path)
        {
            List<string> songs = new List<string>();
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "song")
                    {                        
                        songs.Add(reader.GetAttribute("title"));
                    }
                }
            }

            return songs;
        }

        public static void SaveAlbumsWithAuthors(string input, string output)
        {
            using (XmlReader reader = XmlReader.Create(input))
            {
                using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.Unicode))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {                        
                        if (reader.Name.Equals("album") && reader.IsStartElement())
                        {
                            writer.WriteStartElement("album");
                            reader.ReadToDescendant("name");

                            var name = reader.ReadElementContentAsString();

                            reader.ReadToNextSibling("artist");

                            var artist = reader.ReadElementContentAsString();

                            writer.WriteElementString("name", name);
                            writer.WriteElementString("artist", artist);
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
        }

        public static void CreateXmlFromDirectory(string path, string output)
        {
            using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                AddDirectory(path, writer);
            }
        }

        private static void AddDirectory(string directory, XmlTextWriter writer)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);

            writer.WriteStartElement("dir");
            var directoryName = directory.Split(new char[] { '\\' });
            writer.WriteAttributeString("name", directoryName[directoryName.Length - 1]);

            foreach (var subDirectory in subDirectories)
            {
                AddDirectory(subDirectory, writer);
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Split(new char[] { '\\' });
                writer.WriteElementString("file", fileName[fileName.Length - 1]);
            }

            writer.WriteEndElement();
        }    
    }
}
