using Hermes.DataAccess;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Mvc
{
    [Route("api/content")]
    public abstract class ContentController<TContent, TKey> : PersistentItemController<TContent, TKey>
        where TContent : class, IContent<TKey>
        where TKey : IEquatable<TKey>
    {
        #region Constructor

        public ContentController(IContentManager<TContent, TKey> manager) : base(manager)
        {
            _manager = manager as IContentManager<TContent, TKey>;
        }

        new protected IContentManager<TContent, TKey> _manager;

        #endregion

        //GET
        #region read single by slug

        [HttpGet]
        [Route("single")]
        public virtual async Task<IActionResult> FindBySlug([FromQuery]string slug)
        {
            var items = await _manager.FindBySlugAsync(slug);
            return new ObjectResult(items);
        }

        #endregion
    }
}
