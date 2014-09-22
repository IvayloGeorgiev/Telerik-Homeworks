namespace MongoDbChat.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDbServer;
    using MongoDbServer.Models;

    class MainEntry
    {
        static void Main(string[] args)
        {
            var ctx = new MongoChatConnector("mongodb://testing:testing@ds063789.mongolab.com:63789/mongo-db-chat-test");

            string user = "Testing";
            //PrintMessages(ctx.GetAllMessages());
            ctx.PostMessage("Haio", user, DateTime.Now);
            PrintMessages(ctx.GetAllMessages());
            PrintMessages(ctx.GetAllMessagesSince(DateTime.Now.AddSeconds(-30)));
        }

        private static void PrintMessages(IEnumerable<Message> messages)
        {
            Console.WriteLine("All messages:\n");
            foreach (var message in messages)
            {
                Console.WriteLine("{0} said on {1}:\n\t{2}", message.User.Username, message.PostDate, message.Text);
            }
            Console.WriteLine("-------------------------------------");
        }
    }
}
