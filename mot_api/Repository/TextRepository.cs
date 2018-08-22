using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using mot_api.Data;
using mot_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.ViewModels
{
    public class TextRepository : ITextRepository
    {
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
                //manage exeptions in the future
                throw ex;
            }
        }

        public async Task<TextModel> GetText(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.TextMongo.Find(q => q.InternalId == internalId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id) //change id for ObjectID mongo
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task ChangeText(string id, string textChange)
        {
            if (!string.IsNullOrWhiteSpace(textChange))
            {
                try
                {
                    ObjectId internalId = GetInternalId(id);
                    var filter = Builders<TextModel>.Filter.Eq(q => q.InternalId, internalId);
                    var update = Builders<TextModel>.Update.Set(q => q.name, textChange);

                    UpdateResult actionResult = await _context.TextMongo.UpdateOneAsync(filter, update);

                }
                catch (Exception ex)
                {
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
