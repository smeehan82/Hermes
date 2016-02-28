using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    interface IContentManager<TContent, TKey> : IPersistentItemManager<TContent, TKey>
        where TContent : class, IContent<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TContent> FindBySlugAsync(string slug);

        Task<string> GenerateNewSlug(string source);
        Task<string> NormalizeSlug(string source);
    }
}
