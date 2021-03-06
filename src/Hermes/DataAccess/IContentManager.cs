﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IContentManager<TContent, TKey> : IPersistentItemManager<TContent, TKey>
        where TContent : class, IContent<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TContent> FindBySlugAsync(string slug);

        Task<string> GenerateNewSlugAsync(string source);
        Task<string> NormalizeSlugAsync(string source);
    }
}
