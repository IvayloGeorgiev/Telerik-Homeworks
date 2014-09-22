namespace UsingXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    class MainEntry
    {
        private const string CataloguePath = "../../../catalogue.xml";
        private const string PersonText = "../../../people.txt";
        private const string PersonXml = "../../../people.xml";
        private const string JustNames = "../../../catalogue-names.xml";
        private const string DirectoriesXml = "../../../directories.xml";
        private const string DirectoriesXmlLinq = "../../../directories-linq.xml";

        static void Main(string[] args)
        {
            //CatalogueGenerator.Generate("../../../catalogue.xml");
            //Task 2
            var artistsFromDom = DomOperations.GetArtistsAndAlbumCount(CataloguePath);
            foreach (var pair in artistsFromDom)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("\n------------------------------------\n");
            //Task 3
            var artistsFromXpath = XPathOperations.GetArtistsAndAlbumCount(CataloguePath);
            foreach (var pair in artistsFromXpath)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("\n------------------------------------\n");
            //Task 4
            DomOperations.DeleteAllAbovePrice(CataloguePath, 20m);

            Console.WriteLine("\n------------------------------------\n");
            //Task 5
            Console.WriteLine("Song names:\n{0}", string.Join(", ", XmlReadWrite.ExtractSongTitles(CataloguePath)));

            Console.WriteLine("\n------------------------------------\n");
            //Task  6
            Console.WriteLine("Song names:\n{0}", string.Join(", ", XmlWithLinq.GetAllSongs(CataloguePath)));
            
            Console.WriteLine("\n------------------------------------\n");
            //Task 7
            XmlWithLinq.CreateXmlPersons(PersonText, PersonXml);

            Console.WriteLine("\n------------------------------------\n");
            //Task 8
            XmlReadWrite.SaveAlbumsWithAuthors(CataloguePath, JustNames);

            Console.WriteLine("\n------------------------------------\n");
            //Task 9
            XmlReadWrite.CreateXmlFromDirectory("../../../", DirectoriesXml);

            Console.WriteLine("\n------------------------------------\n");
            //Task 10
            XmlWithLinq.CreateXmlFromDirectory("../../../", DirectoriesXmlLinq);

            Console.WriteLine("\n------------------------------------\n");
            //Task 11
            var from = XPathOperations.GetAlbumsWithPricesFrom(CataloguePath, 1993);
            foreach (var pair in from)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("\n------------------------------------\n");
            //Task 12
            var fromLinq = XmlWithLinq.GetAlbumsWithPricesFrom(CataloguePath, 1993);
            foreach (var pair in fromLinq)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
