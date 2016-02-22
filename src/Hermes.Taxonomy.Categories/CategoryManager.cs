using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Taxonomy.Categories
{
    public class CategoryManager
    {
        #region Constructor

        private CategoryStore _categoryStore;
        private ILogger _logger;

        public CategoryManager(CategoryStore categoryStore, ILoggerFactory loggerFactory)
        {
            _categoryStore = categoryStore;
            _logger = loggerFactory.CreateLogger<CategoryManager>();
        }

        #endregion

        #region Category CRUD Operations

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryStore.AddCategoryAsync(category);
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            var categorys = _categoryStore.Categorys;
            return categorys;
        }

        public async Task<Category> FindCategoryAsync(Guid id)
        {
            var category = await _categoryStore.FindCategoryAsync(id);
            return category;
        }

        public async Task<Category> FindCategoryAsync(string slug)
        {
            var category = await _categoryStore.FindCategoryAsync(slug);
            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryStore.UpdateCategoryAsync(category); ;
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _categoryStore.DeleteCategoryAsync(id);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryStore.DeleteCategoryAsync(category);
        }

        #endregion
    }
}
