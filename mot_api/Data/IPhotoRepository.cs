using mot_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Data
{
    public interface IPhotoRepository
    {
        Task ChangePhoto(string id, PhotoModel photoModel);
        Task AddPhoto(PhotoModel photoModel);
        Task<PhotoModel> DeletePhoto(string id);
        Task<PhotoModel> GetPhoto(string id);
        Task<IEnumerable<PhotoModel>> GetCategory(string category);
        Task<IEnumerable<string>> GetCategoryList();
    }
}
