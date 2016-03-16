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
        public HermesErrorDescriber ErrorDescriber { get; } = new HermesErrorDescriber();

        public ContentManager(IContentStore<TContent, TKey> store, IHttpContextAccessor contextAccessor) : base(store, contextAccessor) { }

        #region Overridden Methods

        public override async Task<HermesResult> AddAsync(TContent item)
        {
            var result = DoesTitleExist(item.Title);

            if (result.Succeeded)
            {
                item.Slug = await GenerateNewSlugAsync(item.Title);
                return await base.AddAsync(item);
            }

            return result;
        }

        public override async Task<HermesResult> UpdateAsync(TContent item)
        {
            var result = DoesTitleExist(item.Title);

            if (result.Succeeded)
            {
                return await base.UpdateAsync(item);
            }

            return result;
        }

        #endregion

        public async Task<TContent> FindBySlugAsync(string slug)
        {
            return await _store.Items.FirstOrDefaultAsync(c => c.Slug.Equals(slug), CancellationToken);
        }


        //**********Helper Methods**********//
        //**********************************//
        //**********************************//
        #region GenerateNewSlugAsync

        public virtual Task<string> GenerateNewSlugAsync(string source)
        {
            //@TODO make it international friendly and cleanup the regex and remove small words
            var slug = Regex.Replace(source, @"\s+", "-");
            return Task.FromResult(Regex.Replace(slug.Normalize().ToLowerInvariant(), @"[^\d\w]", "-"));
        }

        #endregion

        #region NormalizeSlug

        public virtual Task<string> NormalizeSlugAsync(string source)
        {
            return Task.FromResult(source.Normalize().ToLowerInvariant());
        }

        #endregion

        #region DoesTitleExist

        protected HermesResult DoesTitleExist(string title)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            {
                return HermesResult.Failed(ErrorDescriber.TitleNotSet());
            }

            return HermesResult.Success;
        }

        #endregion

    }
}
