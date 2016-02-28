using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IPersistentItemManager<TItem, TKey>
        where TItem : class, IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<HermesResult> AddAsync(TItem item);
        IQueryable<TItem> Items { get; }
        Task<TItem> FindByIdAsync(TKey id);
        Task<HermesResult> UpdateAsync(TItem item);
        Task<HermesResult> DeleteByIdAsync(TKey id);
        Task<HermesResult> DeleteAsync(TItem item);
    }
}
