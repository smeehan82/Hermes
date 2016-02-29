using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Hermes.Content.Blogs;

namespace Hermes.Web.Controllers
{
    [Route("api/blogs")]
    public class BlogsController : Controller
    {
        #region Contructor

        private BlogsManager _blogsManager;
        private ILogger _logger;

        public BlogsController(BlogsManager blogsManager, ILoggerFactory loggerFactory)
        {
            _blogsManager = blogsManager;
            _logger = loggerFactory.CreateLogger<BlogsController>();
        }

        #endregion

        //GET Blogs
        #region list

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Get()
        {
            var blogs = _blogsManager.Blogs;
            return new ObjectResult(blogs);
        }

        #endregion

        //GET Blog
        #region single by id

        [HttpGet]
        [Route("single")]
        public async Task<IActionResult> Get(Guid id)
        {
            var blog = await _blogsManager.FindByIdAsync(id);
            return new ObjectResult(blog);
        }

        #endregion

        //GET Blog
        #region single by slug

        [HttpGet]
        [Route("single")]
        public async Task<IActionResult> Get(string slug)
        {
            var blog = await _blogsManager.FindBySlugAsync(slug);
            return new ObjectResult(blog);
        }

        #endregion

        //POST Blog
        #region add
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Put(string title)
        {
            var blog = new Blog();

            blog.Title = title;

            await _blogsManager.AddAsync(blog);
            return new ObjectResult(true);
        }

        #endregion

        //GET BlogPosts
        #region list

        [HttpGet]
        [Route("list/posts")]
        public async Task<IActionResult> GetPosts(string slug)
        {
            var blog = await _blogsManager.FindBySlugAsync(slug);
            var posts = _blogsManager.BlogPosts.Where(bp => bp.Blog.Equals(blog));
            return new ObjectResult(posts);
        }

        #endregion

        //GET BlogPost
        #region single by slug

        [HttpGet]
        [Route("single/post")]
        public async Task<IActionResult> GetPost(string slug)
        {
            var blogPost = await _blogsManager.FindPostBySlugAsync(slug);
            return new ObjectResult(blogPost);
        }

        #endregion

        //POST BlogPost
        #region add

        [HttpPost]
        [Route("add/post")]
        public async Task<IActionResult> PutPost(string title, string blogSlug)
        {
            var blog = await _blogsManager.FindBySlugAsync(blogSlug);
            var blogPost = new BlogPost();

            blogPost.Blog = blog;
            blogPost.BlogId = blog.Id;
            blogPost.Content = "";
            blogPost.Title = title;

            await _blogsManager.AddPostAsync(blogPost);
            return new ObjectResult(true);
        }

        #endregion
    }
}
