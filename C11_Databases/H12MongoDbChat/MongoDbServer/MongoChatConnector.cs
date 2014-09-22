namespace MongoDbServer
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using MongoDbServer.Models;
    using MongoDB.Driver.Builders;

    public class MongoChatConnector
    {
        private static MongoClient client;        

        public MongoChatConnector(string path)
        {            
            client = new MongoClient(path);
        }

        public IEnumerable<Message> GetAllMessages() 
        {
            var db = this.GetDatabase();
            var allMessages = db.GetCollection<Message>("Messages")
                .FindAll()
                .SetSortOrder(SortBy.Ascending("Date"));

            return allMessages;
        }

        public IEnumerable<Message> GetAllMessagesSince(DateTime since)
        {
            var db = this.GetDatabase();
            var query = Query<Message>.Where(message => message.PostDate > since);
            var newMessages = db.GetCollection<Message>("Messages").Find(query);

            return newMessages;
        }        

        public void PostMessage(string text, string username, DateTime postDate)
        {
            var db = this.GetDatabase();
            var messages = db.GetCollection<Message>("Messages");
            var user = GetUser(username);
            var newMessage = new Message()
            {
                PostDate = postDate,
                Text = text,
                User = user
            };
            messages.Insert(newMessage);
        }

        private User GetUser(string name)
        {
            var db = this.GetDatabase();
            var query = Query<User>.Where(user => user.Username == name);
            var users = db.GetCollection<User>("Users");
            var userInfo = users.Find(query).FirstOrDefault();

            if (userInfo == null)
            {
                userInfo = new User()
                {
                    Username = name
                };
                users.Insert(userInfo);
            }

            return userInfo;
        }

        private MongoDatabase GetDatabase()
        {
            var server = client.GetServer();
            return server.GetDatabase("mongo-db-chat-test");
        }
    }
}
