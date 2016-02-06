using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Hermes.Blogs
{
    public class BlogsManager
    {
        private BlogStore _blogStore;
        private ILogger _logger;

        public BlogsManager(BlogStore blogStore, ILoggerFactory loggerFactory)
        {
            _blogStore = blogStore;
            _logger = loggerFactory.CreateLogger<BlogsManager>();
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            var blogs = await _blogStore.GetBlogsAsync();
            return blogs;
        }
    }
}
