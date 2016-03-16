using Hermes.DataAccess;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public interface IPageManager : IPersistentItemManager<Page, Guid>
    {
        IQueryable<Page> Pages { get; }
    }

    public class PageManager : PersistentItemManager<Page>, IPageManager
    {
        #region Constructor

        private ILogger _logger;

        public PageManager(IPageStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory) : base(store, contextAccessor)
        {
            _logger = loggerFactory.CreateLogger<PageManager>();
        }

        #endregion

        public IQueryable<Page> Pages { get { return _store.Items; } }
        public HermesErrorDescriber ErrorDescriber { get; } = new HermesErrorDescriber();

        #region Overridden Methods

        public override async Task<HermesResult> AddAsync(Page page)
        {
            var result = DoesNameExist(page.Name);

            if (result.Succeeded)
            {
                page.Path = await GenerateNewPathAsync(page.Name);
                return await base.AddAsync(page);
            }

            return result;
        }

        #endregion

        //**********Helper Methods**********//
        //**********************************//
        //**********************************//
        #region GenerateNewSlugAsync

        public virtual Task<string> GenerateNewPathAsync(string source)
        {
            //@TODO make it international friendly and cleanup the regex and remove small words
            var slug = Regex.Replace(source, @"\s+", "-");
            return Task.FromResult(Regex.Replace(slug.Normalize().ToLowerInvariant(), @"[^\d\w]", "-"));
        }

        #endregion

        #region NormalizeSlug

        public virtual Task<string> NormalizePathAsync(string source)
        {
            return Task.FromResult(source.Normalize().ToLowerInvariant());
        }

        #endregion

        #region DoesNameExist

        protected HermesResult DoesNameExist(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return HermesResult.Failed(ErrorDescriber.TitleNotSet());
            }

            return HermesResult.Success;
        }

        #endregion
    }
}
