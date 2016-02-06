using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Blogs
{
    public class Blog : IContent
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DatePublished { get; set; }
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        //Guid IPersistentItem<Guid>.Id { get; set; }
    }
}
