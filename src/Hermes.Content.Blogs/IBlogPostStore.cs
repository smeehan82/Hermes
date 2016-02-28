using Hermes.DataAccess;
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
}
