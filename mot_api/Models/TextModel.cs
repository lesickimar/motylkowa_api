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
        public int id { get; set; }
        public string text { get; set; }

        public TextModel(int _id, string _text)
        {
            id = _id;
            text = _text;
        }
    }


    public class TextModel2
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string name { get; set; }
        public int age { get; set; }
    }
}
