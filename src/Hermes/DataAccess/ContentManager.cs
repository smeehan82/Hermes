using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public abstract class ContentManager<TContent, TKey> : PersistentItemManager<TContent, TKey>, IContentManager<TContent, TKey>
        where TContent : class, IContent<TKey>
        where TKey : IEquatable<TKey>
    {
        public ContentManager(IContentStore<TContent, TKey> store, IHttpContextAccessor contextAccessor) : base(store, contextAccessor) { }

        public async Task<TContent> FindBySlugAsync(string slug)
        {
            return await _store.Items.FirstOrDefaultAsync(c => c.Slug.Equals(slug), CancellationToken);
        }


        //**********Helper Methods**********//
        //**********************************//
        //**********************************//
        public virtual Task<string> GenerateNewSlug(string source)
        {
            //@TODO make it international friendly and cleanup the regex and remove small words
            var slug = Regex.Replace(source, @"\s+", "-");
            return Task.FromResult(Regex.Replace(slug.Normalize().ToLowerInvariant(), @"[^\d\w]", "-"));
        }

        public virtual Task<string> NormalizeSlug(string source)
        {
            return Task.FromResult(source.Normalize().ToLowerInvariant());
        }
    }
}
