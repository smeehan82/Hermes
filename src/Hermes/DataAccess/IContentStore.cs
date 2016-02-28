using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IContentStore<TContent, TKey> : IPersisteneItemStore<TContent, TKey>
        where TContent : class, IContent<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TContent> FindBySlugAsync(string slug, CancellationToken cancellationToken = default(CancellationToken));
    }
}
