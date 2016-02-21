using Hermes.DataAccess;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Blogs
{
    public class BlogPostStore
    {
        #region Contructor

        private IDataContext _context;
        private ILogger _logger;

        public BlogPostStore(IDataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<BlogPostStore>();
        }

        #endregion

        #region CRUD Operations

        public async Task AddBlogPostAsync(BlogPost blogPost)
        {
            _context.Create(blogPost);
            await _context.SaveAsync();
        }

        public virtual IQueryable<BlogPost> BlogPosts
        {
            get { return _context.Set<BlogPost>(); }
        }

        public async Task<BlogPost> FindBlogPostAsync(Guid blogPostId)
        {
            return await BlogPosts.Where(bp => bp.Id == blogPostId).FirstOrDefaultAsync();
        }

        public async Task<BlogPost> FindBlogPostAsync(string slug)
        {
            return await BlogPosts.Where(bp => bp.Slug == slug).FirstOrDefaultAsync();
        }

        public async Task UpdateBlogPostAsync(BlogPost blogPost)
        {
            _context.Update(blogPost);
            await _context.SaveAsync();
        }

        public async Task DeleteBlogPostAsync(Guid id)
        {
            _context.Delete<BlogPost>(id);
            await _context.SaveAsync();
        }

        public async Task DeleteBlogPostAsync(BlogPost blogPost)
        {
            _context.Delete(blogPost);
            await _context.SaveAsync();
        }

        #endregion
    }
}
