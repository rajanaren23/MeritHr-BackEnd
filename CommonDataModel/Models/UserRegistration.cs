using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDataModel.Models
{
    public class UserRegistration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Age { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Department { get; set; }

        public string Region { get; set; }
    }
}
