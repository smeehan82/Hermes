using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Blogs
{
    public class BlogStore
    {
        private IEnumerable<Blog> _blogs;
        private ILogger _logger;

        public BlogStore(ILoggerFactory loggerFactory)
        {
            _blogs = new List<Blog>()
            {
                new Blog()
                {
                    DateCreated = DateTimeOffset.UtcNow,
                    DateModified = DateTimeOffset.UtcNow,
                    DatePublished = DateTimeOffset.UtcNow,
                    Slug = "Test-1",
                    Title = "Test 1",
                    Id = Guid.NewGuid()
                },
                new Blog()
                {
                    DateCreated = DateTimeOffset.UtcNow,
                    DateModified = DateTimeOffset.UtcNow,
                    DatePublished = DateTimeOffset.UtcNow,
                    Slug = "Test-2",
                    Title = "Test 2",
                    Id = Guid.NewGuid()
                }
            };

            _logger = loggerFactory.CreateLogger<BlogStore>();
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            return _blogs;
        }
    }
}
