using Hermes.DataAccess;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Blogs
{
    public class BlogStore
    {
        #region Contructor

        private IDataContext _context;
        private ILogger _logger;

        public BlogStore(IDataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<BlogStore>();
        }

        #endregion

        #region CRUD Operations

        public async Task AddBlogAsync(Blog blog)
        {
            _context.Create(blog);
            await _context.SaveAsync();
        }

        public virtual IQueryable<Blog> Blogs
        {
            get { return _context.Set<Blog>(); }
        }

        public async Task<Blog> FindBlogAsync(Guid id)
        {
            return await Blogs.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Blog> FindBlogAsync(string slug)
        {
            return await Blogs.Where(b => b.Slug == slug).FirstOrDefaultAsync();
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            _context.Update(blog);
            await _context.SaveAsync();
        }

        public async Task DeleteBlogAsync(Guid id)
        {
            _context.Delete<Blog>(id);
            await _context.SaveAsync();
        }

        public async Task DeleteBlogAsync(Blog blog)
        {
            _context.Delete(blog);
            await _context.SaveAsync();
        }

        #endregion
    }
}
