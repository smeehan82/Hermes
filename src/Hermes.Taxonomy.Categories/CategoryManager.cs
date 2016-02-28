using Hermes.DataAccess;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Taxonomy.Categories
{
    public class CategoryManager : TaxonomyManager<Category, Guid>
    {
        #region Constructor

        private ILogger _logger;

        public CategoryManager(CategoryStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory) : base(store, contextAccessor)
        {
            _logger = loggerFactory.CreateLogger<CategoryManager>();
        }

        #endregion

        public IQueryable<Category> Categories { get { return _store.Items; } }
    }
}
