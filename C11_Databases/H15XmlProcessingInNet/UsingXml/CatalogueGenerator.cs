namespace UsingXml
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public class CatalogueGenerator
    {
        private static readonly string[] songNamesConstructor = new string[] { "how", "cow", "brown", "frown", "nothing", "else", "matters", "enter", "sandman", "nevermore", "eat", "crow", "elephant", "big", "guns", "system", "destroy", "gringo", "horizon", "slay" };

        private static readonly string[] artistNames = new string[] { "Metallica", "Nevermore", "System of a Down", "Random Guys", "Shturcite" };

        private static Random rand = new Random();

        public static void Generate(string path)
        {
            XElement root = new XElement("albums");
            for (int i = 0; i < 100; i++)
            {
                root.Add(GenerateAlbum());
            }
            root.Save(path);
        }

        private static XElement GenerateAlbum()
        {
            var album = new XElement("album",
                    new XElement("name", GenerateSongName()),
                    new XElement("artist", GenerateArtist()),
                    new XElement("year", rand.Next(1990, 2010)),
                    new XElement("producer", "Bobby Turboto"),
                    new XElement("price", GeneratePrice()),
                    new XElement("songs", GenerateSongs())
                    );

            return album;
        }

        private static IEnumerable<XElement> GenerateSongs()
        {
            List<XElement> result = new List<XElement>();
            int songCount = rand.Next(1, 6);

            for (int i = 0; i < songCount; i++)
            {
                var song = new XElement("song",
                    new XAttribute("title", GenerateSongName()),
                    new XAttribute("duration", GenerateDuration()));
                result.Add(song);
            }

            return result;
        }

        private static string GenerateSongName()
        {
            var wordCount = rand.Next(2, 5);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < wordCount; i++)
            {
                var nextWordIndex = rand.Next(0, songNamesConstructor.Length);
                sb.Append(songNamesConstructor[nextWordIndex] + " ");
            }

            return sb.ToString();
        }

        private static string GenerateArtist()
        {
            var artistIndex = rand.Next(0, artistNames.Length);
            return artistNames[artistIndex];
        }

        private static decimal GeneratePrice()
        {
            decimal price = Math.Round((decimal)(5 + (rand.NextDouble() * 20)), 2);
            return price;
        }

        private static string GenerateDuration()
        {
            int minutes = rand.Next(1, 6);
            int seconds = rand.Next(0, 61);
            StringBuilder result = new StringBuilder();
            result.Append(minutes);
            result.Append(":");
            result.Append(seconds > 9 ? seconds.ToString() : ("0" + seconds));

            return result.ToString();
        }
    }
}
