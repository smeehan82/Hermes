using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Hermes.DataAccess;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;

namespace Hermes.Content.Blogs
{
    public interface IBlogsManager : IContentManager<Blog, Guid>
    {
        IQueryable<Blog> Blogs { get; }
        IQueryable<BlogPost> BlogPosts { get; }
    }

    public class BlogsManager : ContentManager<Blog, Guid>, IBlogsManager
    {
        #region Constructor

        private IBlogStore _blogStore;
        private IBlogPostStore _blogPostsStore;
        private ILogger _logger;

        public BlogsManager(IBlogStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory, IBlogPostStore blogPostsStore)
            : base(store, contextAccessor)
        {
            _blogPostsStore = blogPostsStore;
            _logger = loggerFactory.CreateLogger<BlogsManager>();
        }

        #endregion

        public IQueryable<Blog> Blogs { get { return _store.Items; } }
        public IQueryable<BlogPost> BlogPosts { get { return _blogPostsStore.Items; } }

        #region BlogPost CRUD Operations

        public virtual async Task<HermesResult> AddPostAsync(BlogPost blogPost, Blog blog)
        {
            var result = DoesTitleExist(blogPost.Title);
            if (result.Succeeded)
            {
                blogPost.Blog = blog;
                blogPost.BlogId = blog.Id;
                return await _blogPostsStore.AddAsync(blogPost, CancellationToken);
            }

            return result;
        }

        public async Task<BlogPost> FindPostByIdAsync(Guid id)
        {
            var blogPost = await _blogPostsStore.FindByIdAsync(id, CancellationToken);
            return blogPost;
        }

        public async Task<BlogPost> FindPostBySlugAsync(string slug)
        {
            return await _blogPostsStore.Items.FirstOrDefaultAsync(c => c.Slug.Equals(slug), CancellationToken);
        }

        public virtual async Task<HermesResult> UpdatePostAsync(BlogPost blogPost)
        {
            var result = DoesTitleExist(blogPost.Title);
            if (result.Succeeded)
            {
                return await _blogPostsStore.UpdateAsync(blogPost, CancellationToken);
            }

            return result;
        }

        public virtual async Task<HermesResult> DeletePostAsync(BlogPost blogPost)
        {
            return await _blogPostsStore.DeleteAsync(blogPost, CancellationToken);
        }

        public virtual async Task<HermesResult> DeletePostByIdAsync(Guid id)
        {
            var blogPost = await FindPostByIdAsync(id);
            return await _blogPostsStore.DeleteAsync(blogPost, CancellationToken);
        }

        #endregion
    }
}
