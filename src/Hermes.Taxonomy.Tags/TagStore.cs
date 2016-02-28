using Hermes.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Hermes.Taxonomy.Tags
{
    public class TagStore : TaxonomyStore<Tag>, ITagStore
    {
        #region Contructor

        public TagStore(IDataContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<TagStore>();
        }

        #endregion

        public IQueryable<Tag> Tags { get { return Items; } }
    }
}
