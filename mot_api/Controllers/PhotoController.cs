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
        public async Task<PhotoModel> GetPhoto(string id)
        {
            return await _photoRepository.GetPhoto(id);
        }
            
        [HttpGet("category/{category}")]
        public async Task<IEnumerable<PhotoModel>> GetCategory(string category)
        {
            return await _photoRepository.GetCategory(category);
        }

        [HttpGet("categorylist")]
        public async Task<IEnumerable<string>> GetCategoryList()
        {
            return await _photoRepository.GetCategoryList();
        }

        [HttpPost]
        public async Task AddPhoto([FromBody] PhotoModel photoModel)
        {
            await _photoRepository.AddPhoto(photoModel);
        }

        [HttpPut("{id}")]
        public async Task ChangePhoto(string id, [FromBody] PhotoModel photoModel)
        {
            await _photoRepository.ChangePhoto(id, photoModel);
        }
    }
}