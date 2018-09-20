using mot_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mot_api.Data
{
    public interface IPhotoRepository
    {
        //Task ChangePhoto(int id, PhotoModel photoModel);
        //Task AddPhoto(PhotoModel photoModel);
        //Task DeletePhoto(int id);
        Task<PhotoModel> GetPhoto(int id);
        Task<IEnumerable<PhotoModel>> GetGallery(int gallery);
        Task<IEnumerable<string>> GetGalleryList();
    }
}
