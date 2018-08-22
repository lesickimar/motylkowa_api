using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Models
{
    public class PhotoModel
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string name { get; set; }
        public string url { get; set; }
        public string category { get; set; }
    }
}
