using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Hermes.DataAccess;
using Microsoft.AspNet.Http;

namespace Hermes.Taxonomy.Tags
{
    public class TagManager : TaxonomyManager<Tag, Guid>
    {
        #region Constructor

        private ILogger _logger;

        public TagManager(ITagStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory) : base(store, contextAccessor)
        {
            _logger = loggerFactory.CreateLogger<TagManager>();
        }

        #endregion

        public IQueryable<Tag> Tags { get { return _store.Items; } }
    }
}
