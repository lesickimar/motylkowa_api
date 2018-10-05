using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using mot_api.Configuration;
using mot_api.Data;
using mot_api.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.ViewModels
{
    public class TextRepository : ITextRepository
    {
        private EmailSender email = new EmailSender();
        private readonly MongoContext _context = null;

        public TextRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }



        public async Task<IEnumerable<TextModel>> GetAllText()
        {
            try
            {
                return await _context.TextMongo.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Get all text download");
                throw ex;
            }
        }

        public async Task<TextModel> GetText(int id)
        {
            try
            {
                //ObjectId internalId = GetInternalId(id);
                return await _context.TextMongo.Find(q => q.id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Get text by id download");
                throw ex;
            }
        }

        //private ObjectId GetInternalId(string id) //change id for ObjectID mongo
        //{
        //    ObjectId internalId;
        //    if (!ObjectId.TryParse(id, out internalId))
        //        internalId = ObjectId.Empty;

        //    return internalId;
        //}

        public async Task ChangeText(JObject textChange)
        {
            var _textChange = textChange.ToObject<TextModel>();
            if (!string.IsNullOrWhiteSpace(_textChange.text))
            {
                try
                {
                    //ObjectId internalId = GetInternalId(id);
                    var filter = Builders<TextModel>.Filter.Eq(q => q.id, _textChange.id);
                    var update = Builders<TextModel>.Update.Set(q => q.text, _textChange.text);

                    UpdateResult actionResult = await _context.TextMongo.UpdateOneAsync(filter, update);

                }
                catch (Exception ex)
                {
                    email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Change text by id download");
                    throw ex;
                }
            }            
        }

        //public List<TextModel> SendTextFromID(int id)
        //{
        //    List<TextModel> newList = new List<TextModel>();

        //    newList.Add(new TextModel(id, "dupa"));

        //    return newList;
        //}

        //public void SaveTextFromID(TextModel text)
        //{
        //    //find in mongo by ID
        //    //check its not null ID
        //    //update text
        //    //save in mongo
        //}

    }
}
