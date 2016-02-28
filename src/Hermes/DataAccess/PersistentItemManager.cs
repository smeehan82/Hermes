using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace Hermes.DataAccess
{
    public abstract class PersistentItemManager<TItem, TKey> : IPersistentItemManager<TItem, TKey>
        where TItem : class, IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        #region Contructor

        protected IPersisteneItemStore<TItem, TKey> _store;
        protected ILogger _logger;
        protected CancellationToken CancellationToken => _httpContext?.RequestAborted ?? CancellationToken.None;
        protected HttpContext _httpContext;

        public PersistentItemManager(IPersisteneItemStore<TItem, TKey> store, IHttpContextAccessor contextAccessor)
        {
            _store = store;
            _httpContext = contextAccessor.HttpContext;
        }

        #endregion

        #region CRUD Operations

        public virtual async Task<HermesResult> AddAsync(TItem item)
        {
            return await _store.AddAsync(item, CancellationToken);
        }

        public IQueryable<TItem> Items { get { return _store.Items; } }

        public async Task<TItem> FindByIdAsync(TKey id)
        {
            var item = await _store.FindByIdAsync(id, CancellationToken);
            return item;
        }

        public virtual async Task<HermesResult> UpdateAsync(TItem item)
        {
            return await _store.UpdateAsync(item, CancellationToken);
        }

        public virtual async Task<HermesResult> DeleteAsync(TItem item)
        {
            return await _store.DeleteAsync(item, CancellationToken);
        }

        public virtual async Task<HermesResult> DeleteByIdAsync(TKey id)
        {
            var item = await FindByIdAsync(id);
            return await _store.DeleteAsync(item, CancellationToken);
        }

        #endregion
    }
}
