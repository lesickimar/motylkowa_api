using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Models
{
    public class TextModel 
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public int id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
    }


}
