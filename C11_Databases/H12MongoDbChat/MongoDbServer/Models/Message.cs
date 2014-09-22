﻿namespace MongoDbServer.Models
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        public Message()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public User User { get; set; }
    }
}
