using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using mot_api.Configuration;
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
        private EmailSender email = new EmailSender();
        private readonly MongoContext _context = null;

        public PhotoRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }

        //private ObjectId GetInternalId(string id) //change id for ObjectID mongo
        //{
        //    ObjectId internalId;
        //    if (!ObjectId.TryParse(id, out internalId))
        //        internalId = ObjectId.Empty;

        //    return internalId;
        //}

        public async Task<PhotoModel> GetPhoto(int id)
        {
            try
            {
                return await _context.PhotoMongo.Find(q => q.id_photo == id).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Get Photo by id");
                throw ex;
            }
        }

        public async Task<IEnumerable<PhotoModel>> GetGallery(string galleryName)
        {
            try
            {
                return await _context.PhotoMongo.Find(q => q.name_gallery == galleryName).ToListAsync();
            }
            catch (Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Gallery download");
                throw ex;
            }
        }

        public async Task<IEnumerable<string>> GetGalleryList()
        {
            try
            {
                var fullList =  await _context.PhotoMongo.Find(_ => true).ToListAsync();
                return fullList.Select(q => q.name_gallery).Distinct().ToList();
            }
            catch (Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Gallery list by name");
                throw ex;
            }
        }

        public async Task AddPhoto(PhotoModel newPhoto) //to do
        {
            try
            {
                await _context.PhotoMongo.InsertOneAsync(newPhoto);
            }
            catch(Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Add photo");
                throw ex;
            }
        }

        //public async Task ChangePhoto(string id, PhotoModel photoModel)
        //{
        //    if(!string.IsNullOrWhiteSpace(id))
        //    {
        //        try
        //        {
        //            ObjectId internalId = GetInternalId(id);
        //            var filter = Builders<PhotoModel>.Filter.Eq(q => q.InternalId, internalId);
        //            var update = Builders<PhotoModel>.Update.Set(q => q.name, photoModel.name)
        //                .Set(q => q.category, photoModel.category)
        //                .Set(q => q.url, photoModel.url);

        //            UpdateResult actionResult = await _context.PhotoMongo.UpdateOneAsync(filter, update);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //public Task<PhotoModel> DeletePhoto(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
