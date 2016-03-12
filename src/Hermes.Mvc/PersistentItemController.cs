using Hermes.DataAccess;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Mvc
{
    public abstract class PersistentItemController<TItem, TKey> : Controller
        where TItem : class, IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        public PersistentItemController(IPersistentItemManager<TItem, TKey> manager)
        {
            _manager = manager;
        }

        protected IPersistentItemManager<TItem, TKey> _manager;
        protected ILoggerFactory _logger;

        //GET
        #region list

        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> Get()
        {
            var items = _manager.Items;
            return new ObjectResult(items);
        }

        #endregion

        //GET
        #region list

        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> Find([FromQuery]TKey id)
        {
            var items = _manager.Items;
            return new ObjectResult(items);
        }

        #endregion
    }

    public abstract class PersistentItemController<TItem> : PersistentItemController<TItem, Guid>
        where TItem : class, IPersistentItem<Guid>
    {
        public PersistentItemController(IPersistentItemManager<TItem, Guid> manager) : base(manager) { }
    }
}
