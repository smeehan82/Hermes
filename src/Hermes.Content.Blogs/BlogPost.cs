using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Blogs
{
    public class BlogPost : IContent, IPersistentItem
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DatePublished { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }


        public string Content { get; set; }
        public Blog Blog { get; set; }
        public Guid BlogId { get; set; }
    }
}
