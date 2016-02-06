using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Hermes.Blogs;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hermes.Web.Controllers
{
    [Route("api/blogs")]
    public class BlogsController : Controller
    {
        private BlogsManager _blogsManager;
        private ILogger _logger;

        public BlogsController(BlogsManager blogsManager, ILoggerFactory loggerFactory)
        {
            _blogsManager = blogsManager;
            _logger = loggerFactory.CreateLogger<BlogsController>();
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogs = await _blogsManager.GetBlogsAsync();
            return new ObjectResult(blogs);
        }
    }
}
