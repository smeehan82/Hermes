using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IPersisteneItemStore<TItem, TKey>
        where TItem : class, IPersistentItem<TKey> 
        where TKey: IEquatable<TKey>
    {
        Task AddAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken));
        IQueryable<TItem> Items { get; }
        Task<TItem> FindByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));

        Task<TKey> GenerateKeyAsync();
    }
}
