using Hermes.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public interface IPageStore : IPersisteneItemStore<Page, Guid>
    {
        IQueryable<Page> Pages { get; }
    }

    public class PageStore : PersistentItemStore<Page>, IPageStore
    {
        #region Contructor

        public PageStore(IDataContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<PageStore>();
        }

        #endregion

        public IQueryable<Page> Pages { get { return Items; } }
    }
}
