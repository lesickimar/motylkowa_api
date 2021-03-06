﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mot_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<TextModel> TextMongo
        {
            get
            {
                return _database.GetCollection<TextModel>("mot_text");
            }
        }

        public IMongoCollection<PhotoModel> PhotoMongo
        {
            get
            {
                return _database.GetCollection<PhotoModel>("mot_photo");
            }
        }

        public IMongoCollection<DocumentModel> DocumentMongo
        {
            get
            {
                return _database.GetCollection<DocumentModel>("mot_doc");
            }
        }
    }
}
