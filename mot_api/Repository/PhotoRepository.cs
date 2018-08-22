using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using mot_api.Data;
using mot_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly MongoContext _context = null;

        public PhotoRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }

        private ObjectId GetInternalId(string id) //change id for ObjectID mongo
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task<PhotoModel> GetPhoto(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.PhotoMongo.Find(q => q.InternalId == internalId).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PhotoModel>> GetCategory(string category)
        {
            try
            {
                return await _context.PhotoMongo.Find(q => q.category == category).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<string>> GetCategoryList()
        {
            try
            {
                var filter = new BsonDocument();
                var test =  await _context.PhotoMongo.DistinctAsync<string>("category", filter);
                return test.ToEnumerable<string>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddPhoto(PhotoModel newPhoto)
        {
            try
            {
                await _context.PhotoMongo.InsertOneAsync(newPhoto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task ChangePhoto(string id, PhotoModel photoModel)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    ObjectId internalId = GetInternalId(id);
                    var filter = Builders<PhotoModel>.Filter.Eq(q => q.InternalId, internalId);
                    var update = Builders<PhotoModel>.Update.Set(q => q.name, photoModel.name)
                        .Set(q => q.category, photoModel.category)
                        .Set(q => q.url, photoModel.url);

                    UpdateResult actionResult = await _context.PhotoMongo.UpdateOneAsync(filter, update);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Task<PhotoModel> DeletePhoto(string id)
        {
            throw new NotImplementedException();
        }
    }
}
