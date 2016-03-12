using Hermes.DataAccess;
using Hermes.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Blogs
{
    public class Blog : IContent, IPersistentItem
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DatePublished { get; set; }
        [PrimaryKey]
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        //Guid IPersistentItem<Guid>.Id { get; set; }
    }
}
