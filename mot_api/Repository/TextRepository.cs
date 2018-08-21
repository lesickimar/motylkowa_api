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



        public async Task<IEnumerable<TextModel2>> GetAllText()
        {
            try
            {
                return await _context.Test.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                //manage exeptions in the future
                throw ex;
            }
        }

        public async Task<TextModel2> GetText(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Test.Find(q => q.InternalId == internalId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
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
