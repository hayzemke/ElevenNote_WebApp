using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote_WebApp.Server.Services.CategoryServices;
using ElevenNote_WebApp.Shared.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElevenNote_WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryEntityController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryEntityController(ICategoryService _categoryService)
        {
            this._categoryService = _categoryService;
        }
            

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null) return Ok(new List<CategoryListItem>());
            return Ok(categories);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Category (int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create (CategoryCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest(ModelState);
            if (await _categoryService.CreateCategoryAsync(model)) return Ok();
            else
            {
                return UnprocessableEntity();
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

