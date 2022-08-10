using System;
using ElevenNote_WebApp.Server.Data;
using ElevenNote_WebApp.Server.Models;
using ElevenNote_WebApp.Shared.Models.CategoryModels;
using ElevenNote_WebApp.Shared.Models.NoteModels;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote_WebApp.Server.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            if (model == null) return false;

            var categoryEntity = new Category
            {
                Name = model.Name
            };

            _context.Categories.Add(categoryEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categoryQuery = _context.Categories
                .Select(entity => new CategoryListItem
                {
                    ID = entity.ID,
                    Name = entity.Name,
                });

            return await categoryQuery.ToListAsync();
        }


        //* finish later
        public Task<bool> DeleteCategoryAsync(int categoryID)
        {
            throw new NotImplementedException();
        }


        public Task<CategoryDetail> GetCategoryByIdAsync(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            throw new NotImplementedException();
        }
    }
}

