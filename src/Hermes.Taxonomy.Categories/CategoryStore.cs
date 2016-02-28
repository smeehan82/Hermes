using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

namespace Hermes.Taxonomy.Categories
{
    public class CategoryStore : TaxonomyStore<Category>, ICategoryStore
    {
        #region Contructor

        public CategoryStore(IDataContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<CategoryStore>();
        }

        #endregion

        public IQueryable<Category> Categories { get { return Items; } }
    }
}
