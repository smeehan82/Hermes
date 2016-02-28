using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Taxonomy.Categories
{
    public interface ICategoryStore : ITaxonomyStore<Category, Guid>
    {
        IQueryable<Category> Categories { get; }
    }
}
