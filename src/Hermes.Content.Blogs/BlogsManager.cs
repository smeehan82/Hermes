using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Hermes.Content.Blogs
{
    public class BlogsManager
    {
        #region Constructor

        private BlogStore _blogStore;
        private BlogPostStore _blogPostStore;
        private ILogger _logger;

        public BlogsManager(BlogStore blogStore, BlogPostStore blogPostStore, ILoggerFactory loggerFactory)
        {
            _blogStore = blogStore;
            _blogPostStore = blogPostStore;
            _logger = loggerFactory.CreateLogger<BlogsManager>();
        }

        #endregion

        #region Blog CRUD Operations

        public async Task AddBlogAsync(Blog blog)
        {
            await _blogStore.AddAsync(blog);
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            var blogs = _blogStore.Blogs;
            return blogs;
        }

        public async Task<Blog> FindBlogAsync(Guid id)
        {
            var blog = await _blogStore.FindByIdAsync(id);
            return blog;
        }

        public async Task<Blog> FindBlogAsync(string slug)
        {
            var blog = await _blogStore.FindBySlugAsync(slug);
            return blog;
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            await _blogStore.UpdateAsync(blog);
        }

        public async Task DeleteBlogAsync(Guid id)
        {
            await _blogStore.DeleteByIdAsync(id);
        }

        public async Task DeleteBlogAsync(Blog blog)
        {
            await _blogStore.DeleteAsync(blog);
        }

        #endregion

        #region BlogPost CRUD Operations

        public async Task AddBlogPostAsync(BlogPost blogPost)
        {
            await _blogPostStore.AddAsync(blogPost);
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            var blogPosts = _blogPostStore.Posts;
            return blogPosts;
        }

        public async Task<BlogPost> FindBlogPostAsync(Guid id)
        {
            var blog = await _blogPostStore.FindByIdAsync(id);
            return blog;
        }

        public async Task<BlogPost> FindBlogPostAsync(string slug)
        {
            var blogPost = await _blogPostStore.FindBySlugAsync(slug);
            return blogPost;
        }

        public async Task UpdateBlogPostAsync(BlogPost blogPost)
        {
            await _blogPostStore.UpdateAsync(blogPost); ;
        }

        public async Task DeleteBlogPostAsync(Guid id)
        {
            await _blogPostStore.DeleteByIdAsync(id);
        }

        public async Task DeleteBlogPostAsync(BlogPost blogPost)
        {
            await _blogPostStore.DeleteAsync(blogPost);
        }

        #endregion
    }
}
