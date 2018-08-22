﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mot_api.Data;
using mot_api.Models;
using mot_api.ViewModels;

namespace mot_api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : Controller
    {

        private readonly ITextRepository _textRepository;

        public TextController(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public async Task<IEnumerable<TextModel>> Get()
        {
            return await _textRepository.GetAllText();
        }

        [HttpGet("{id}")]
        public async Task<TextModel> Get(string id)
        {
            return await _textRepository.GetText(id);
        }

        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] string textChange)
        {
            await _textRepository.ChangeText(id, textChange);
        }
        //private TextViewModel textViewModel = new TextViewModel();


        //[HttpGet("{id}", Name = "lala")]
        //public ActionResult<List<TextModel>> Get(int id)
        //{
        //    List<TextModel> list = textViewModel.SendTextFromID(id);

        //    return list;
        //}



        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] TextModel text)
        //{
        //    textViewModel.SaveTextFromID(text);

        //    return NoContent();
        //}
    }
}