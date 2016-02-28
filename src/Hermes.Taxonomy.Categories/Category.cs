using Hermes.DataAccess;
using Hermes.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Taxonomy.Categories
{
    public class Category : ITaxonomy
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DatePublished { get; set; }
        [PrimaryKey]
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }

        public Category Parent { get; set; }
        public Guid ParentId { get; set; }

        public ICollection<Category> Children { get; set; }
    }
}
