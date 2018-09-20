using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mot_api.Data;
using mot_api.Models;

namespace mot_api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : Controller
    {

        private readonly IPhotoRepository _photoRepository;

        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        [HttpGet("{id}")]
        public async Task<PhotoModel> GetPhoto(int id)
        {
            return await _photoRepository.GetPhoto(id);
        }
            
        [HttpGet("gallery/{gallery}")]
        public async Task<IEnumerable<PhotoModel>> GetGallery(int gallery)
        {
            return await _photoRepository.GetGallery(gallery);
        }

        [HttpGet("gallerylist")]
        public async Task<IEnumerable<string>> GetGalleryList()
        {
            return await _photoRepository.GetGalleryList();
        }

        //[HttpPost]
        //public async Task AddPhoto([FromBody] PhotoModel photoModel)
        //{
        //    await _photoRepository.AddPhoto(photoModel);
        //}

        //[HttpPut("{id}")]
        //public async Task ChangePhoto(string id, [FromBody] PhotoModel photoModel)
        //{
        //    await _photoRepository.ChangePhoto(id, photoModel);
        //}
    }
}