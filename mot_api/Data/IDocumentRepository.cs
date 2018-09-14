using mot_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Data
{
    public interface IDocumentRepository
    {
        Task<string> DownloadFile(int id);
        Task<IEnumerable<DocumentModel>> GetAllDocuments();
    }
}
