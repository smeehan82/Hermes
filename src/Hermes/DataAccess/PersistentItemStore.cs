using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Data.Entity;

namespace Hermes.DataAccess
{
    public abstract class PersistentItemStore<TItem, TKey> : IPersisteneItemStore<TItem, TKey>
        where TItem : class, IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {

        #region Contructor

        private IDataContext _context;
        protected ILogger _logger;

        public PersistentItemStore(IDataContext context)
        {
            _context = context;
        }

        #endregion


        public async Task AddAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Id = await GenerateKeyAsync();

            _context.Add(item);
            await _context.SaveAsync();
        }

        public IQueryable<TItem> Items
        {
            get { return _context.Set<TItem>(); }
        }

        public async Task<TItem> FindByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Items.FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task UpdateAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Attach(item);
            _context.Update(item);
            await _context.SaveAsync();
        }

        public async Task DeleteAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Attach(item);
            _context.Delete(item);
            await _context.SaveAsync();
        }

        public async Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            var itemToDelete = await FindByIdAsync(id);
            await DeleteAsync(itemToDelete, cancellationToken);
        }

        public abstract Task<TKey> GenerateKeyAsync();
    }



    public abstract class PersistentItemStore<TItem> : PersistentItemStore<TItem, Guid>
        where TItem : class, IPersistentItem<Guid>
    {
        public PersistentItemStore(IDataContext context) : base(context) { }

        public override Task<Guid> GenerateKeyAsync()
        {
            return Task.FromResult(Guid.NewGuid());
        }
    }
}
