using Hermes.DataAccess;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Blogs
{
    public interface IBlogPostStore : IContentStore<BlogPost, Guid>
    {
        IQueryable<BlogPost> Posts { get; }
    }

    public class BlogPostStore : ContentStore<BlogPost>, IBlogPostStore
    {
        #region Contructor

        public BlogPostStore(IDataContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<BlogPostStore>();
        }

        #endregion

        public IQueryable<BlogPost> Posts { get { return Items; } }
    }
}