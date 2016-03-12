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
    public interface IBlogManager : IContentManager<Blog, Guid>
    {
        IQueryable<Blog> Blogs { get; }
        IQueryable<BlogPost> BlogPosts { get; }
    }

    public class BlogManager : ContentManager<Blog, Guid>, IBlogManager
    {
        #region Constructor

        private IBlogStore _blogStore;
        private IBlogPostStore _blogPostsStore;
        private ILogger _logger;

        public BlogManager(IBlogStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory, IBlogPostStore blogPostsStore)
            : base(store, contextAccessor)
        {
            _blogPostsStore = blogPostsStore;
            _logger = loggerFactory.CreateLogger<BlogManager>();
        }

        #endregion

        public IQueryable<Blog> Blogs { get { return _store.Items; } }
        public IQueryable<BlogPost> BlogPosts { get { return _blogPostsStore.Items; } }

        #region BlogPost CRUD Operations

        public virtual async Task<HermesResult> AddPostAsync(BlogPost blogPost)
        {
            var result = DoesTitleExist(blogPost.Title);

            if (result.Succeeded)
            {
                var blogResult = DoesBlogExist(blogPost);

                if (blogResult.Succeeded)
                {
                    if (blogPost.Blog != null && blogPost.BlogId == null)
                    {
                        blogPost.BlogId = blogPost.Blog.Id;
                    }
                    else if (blogPost.Blog == null && blogPost.BlogId != null)
                    {
                        var blog = await _store.FindByIdAsync(blogPost.Blog.Id, CancellationToken);
                        blogPost.Blog = blog;                        
                    }

                    return await _blogPostsStore.AddAsync(blogPost, CancellationToken);
                }

                return blogResult;
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

        //**********Helper Methods**********//
        //**********************************//
        //**********************************//
        #region DoesBlogExist

        private HermesResult DoesBlogExist(BlogPost blogPost)
        {
            if (blogPost.Blog == null && blogPost.BlogId == null)
            {
                return HermesResult.Failed(ErrorDescriber.BlogPostDoesNotHaveBlog());
            }

            return HermesResult.Success;
        }

        #endregion
    }
}
