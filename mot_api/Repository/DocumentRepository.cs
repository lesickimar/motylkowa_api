using Microsoft.Extensions.Options;
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
    public class DocumentRepository : IDocumentRepository
    {

        private EmailSender email = new EmailSender();
        private readonly MongoContext _context = null;

        public DocumentRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }

        public async Task<string> DownloadFile(int id)
        {
            try
            {
                var _id = await _context.DocumentMongo.Find(q => q.id == id).FirstOrDefaultAsync();
                var path = @"" + _id.link;
                var byteArray = await System.IO.File.ReadAllBytesAsync(path);
                var fileData = Convert.ToBase64String(byteArray);
                return fileData;
            }
            catch (Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Document download");
                throw ex;
            }
        }

        public async Task<IEnumerable<DocumentModel>> GetAllDocuments()
        {
            try
            {
                return await _context.DocumentMongo.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                email.EmailSend("Stack trace message \n" + ex.StackTrace + "\n Exception full info \n" + ex, "Documents full list");
                throw ex;
            }
        }
    }
}
