using Hermes.DataAccess;
using Hermes.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Quotes
{
    public class Quote : IContent
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DatePublished { get; set; }
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> Sources { get; set; }
        public IEnumerable<string> Speakers { get; set; }
        //Guid IPersistentItem<Guid>.Id { get; set; }
    }
}
