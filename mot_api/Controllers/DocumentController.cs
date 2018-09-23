using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mot_api.Configuration;
using mot_api.Data;
using mot_api.Models;

namespace mot_api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentModel>> Get()
        {
            return await _documentRepository.GetAllDocuments();
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return await _documentRepository.DownloadFile(id);
        }
    }
}