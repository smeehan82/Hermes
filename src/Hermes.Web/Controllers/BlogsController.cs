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

        //GET
        #region list

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Get()
        {
            var blogs = _blogsManager.Blogs;
            return new ObjectResult(blogs);
        }

        #endregion

        //GET
        #region single by id

        [HttpGet]
        [Route("single")]
        public async Task<IActionResult> Get(Guid id)
        {
            var blog = await _blogsManager.FindByIdAsync(id);
            return new ObjectResult(blog);
        }

        #endregion

        //GET
        #region single by slug

        [HttpGet]
        [Route("single")]
        public async Task<IActionResult> Get(string slug)
        {
            var blog = await _blogsManager.FindBySlugAsync(slug);
            return new ObjectResult(blog);
        }

        #endregion

        //POST
        #region add
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Put(string title, string slug)
        {
            var blog = new Blog();

            blog.Id = new Guid();
            blog.Title = title;
            blog.Slug = slug;
            blog.DateCreated = DateTimeOffset.Now;
            blog.DateModified = DateTimeOffset.Now;
            blog.DatePublished = DateTimeOffset.Now;

            await _blogsManager.AddAsync(blog);
            return new ObjectResult(true);
        }

        #endregion
    }
}
