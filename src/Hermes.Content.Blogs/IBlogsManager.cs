using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Blogs
{
    public interface IBlogsManager : IContentManager<Blog, Guid>
    {
        IQueryable<Blog> Blogs { get; }
        IQueryable<BlogPost> BlogPosts { get; }
    }
}
