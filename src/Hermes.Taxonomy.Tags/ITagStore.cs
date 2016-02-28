using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Taxonomy.Tags
{
    public interface ITagStore : ITaxonomyStore<Tag, Guid>
    {
        IQueryable<Tag> Tags { get; }
    }
}
