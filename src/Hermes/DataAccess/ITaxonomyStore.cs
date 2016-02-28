using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface ITaxonomyStore<TTaxonomy, TKey> : IPersisteneItemStore<TTaxonomy, TKey>
        where TTaxonomy : class, ITaxonomy<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TTaxonomy> FindBySlugAsync(string slug, CancellationToken cancellationToken = default(CancellationToken));
    }
}
