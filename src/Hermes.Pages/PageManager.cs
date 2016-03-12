using Hermes.DataAccess;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public interface IPageManager : IPersistentItemManager<Page, Guid>
    {
        IQueryable<Page> Pages { get; }
    }

    public class PageManager : PersistentItemManager<Page>, IPageManager
    {
        #region Constructor

        private ILogger _logger;

        public PageManager(IPageStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory) : base(store, contextAccessor)
        {
            _logger = loggerFactory.CreateLogger<PageManager>();
        }

        #endregion

        public IQueryable<Page> Pages { get { return _store.Items; } }
    }
}
