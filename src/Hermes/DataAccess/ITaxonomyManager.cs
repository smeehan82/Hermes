using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface ITaxonomyManager<TTaxonomy, TKey> : IPersistentItemManager<TTaxonomy, TKey>
        where TTaxonomy : class, ITaxonomy<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TTaxonomy> FindBySlugAsync(string slug);

        Task<string> GenerateNewSlugAsync(string source);
        Task<string> NormalizeSlugAsync(string source);
    }
}
