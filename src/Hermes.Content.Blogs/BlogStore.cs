using Hermes.DataAccess;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Blogs
{
    public interface IBlogStore : IContentStore<Blog, Guid>
    {
        IQueryable<Blog> Blogs { get; }
    }

    public class BlogStore : ContentStore<Blog>, IBlogStore
    {
        #region Contructor

        public BlogStore(IDataContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<BlogStore>();
        }

        #endregion

        public IQueryable<Blog> Blogs { get { return Items; } }
    }
}