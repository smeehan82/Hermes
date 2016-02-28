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
        Task<HermesResult> AddAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken));
        IQueryable<TItem> Items { get; }
        Task<TItem> FindByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
        Task<HermesResult> UpdateAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken));
        Task<HermesResult> DeleteAsync(TItem item, CancellationToken cancellationToken = default(CancellationToken));
        Task<HermesResult> DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));

        Task<TKey> GenerateKeyAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<string> GenerateConcurrencyStampAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
