using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

namespace Hermes.Taxonomy.Categories
{
    public class CategoryStore
    {
        #region Contructor

        private IDataContext _context;
        private ILogger _logger;

        public CategoryStore(IDataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<CategoryStore>();
        }

        #endregion

        #region CRUD Operations

        public async Task AddCategoryAsync(Category category)
        {
            _context.Create(category);
            await _context.SaveAsync();
        }

        public virtual IQueryable<Category> Categorys
        {
            get { return _context.Set<Category>(); }
        }

        public async Task<Category> FindCategoryAsync(Guid id)
        {
            return await Categorys.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> FindCategoryAsync(string slug)
        {
            return await Categorys.Where(b => b.Slug == slug).FirstOrDefaultAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException("This message was not implemented");
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _context.Delete(category);
            await _context.SaveAsync();
        }

        #endregion
    }
}
