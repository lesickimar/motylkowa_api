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

        public int id_gallery { get; set; }
        public string name_gallery { get; set; }
        public int id_photo { get; set; }
        public string name_photo { get; set; }
        public string link { get; set; }
    }
}
