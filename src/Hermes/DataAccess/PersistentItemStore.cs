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
        public HermesErrorDescriber ErrorDescriber { get; } = new HermesErrorDescriber();

        public PersistentItemStore(IDataContext context)
        {
            _context = context;
        }

        #endregion

        #region Create Operation

        public async Task<HermesResult> AddAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Id = await GenerateKeyAsync(cancellationToken);
            item.ConcurrencyStamp = await GenerateConcurrencyStampAsync(cancellationToken);

            _context.Add(item);

            await _context.SaveAsync(cancellationToken);
            return HermesResult.Success;
        }

        #endregion

        #region Read Operations

        public IQueryable<TItem> Items
        {
            get { return _context.Set<TItem>(); }
        }

        public async Task<TItem> FindByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Items.FirstOrDefaultAsync(i => i.Id.Equals(id), cancellationToken);
        }

        #endregion

        #region Update Operation

        public async Task<HermesResult> UpdateAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Attach(item);
            item.ConcurrencyStamp = await GenerateConcurrencyStampAsync(cancellationToken);
            _context.Update(item);

            try
            {
                await _context.SaveAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return HermesResult.Failed(ErrorDescriber.ConcurrencyFailure());
            }

            return HermesResult.Success;
        }

        #endregion

        #region Delete Operations

        public async Task<HermesResult> DeleteAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Delete(item);

            try
            {
                await _context.SaveAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return HermesResult.Failed(ErrorDescriber.ConcurrencyFailure());
            }

            return HermesResult.Success;
        }

        public async Task<HermesResult> DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            var itemToDelete = await FindByIdAsync(id, cancellationToken);
            return await DeleteAsync(itemToDelete, cancellationToken);
        }

        #endregion


        //**********Helper Methods**********//
        //**********************************//
        //**********************************//
        public abstract Task<TKey> GenerateKeyAsync(CancellationToken cancellationToken = default(CancellationToken));

        public virtual Task<string> GenerateConcurrencyStampAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }


    #region Class Definition with the key specified as a Guid

    public abstract class PersistentItemStore<TItem> : PersistentItemStore<TItem, Guid>
    where TItem : class, IPersistentItem<Guid>
    {
        public PersistentItemStore(IDataContext context) : base(context) { }

        public override Task<Guid> GenerateKeyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(Guid.NewGuid());
        }
    }

    #endregion
}
