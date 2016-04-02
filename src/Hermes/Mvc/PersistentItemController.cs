using Hermes.DataAccess;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Mvc
{
    [Route("api/persistent-items")]
    public abstract class PersistentItemController<TItem, TKey> : Controller
        where TItem : class, IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        #region Constructor

        public PersistentItemController(IPersistentItemManager<TItem, TKey> manager)
        {
            _manager = manager;
        }

        protected IPersistentItemManager<TItem, TKey> _manager;
        protected ILoggerFactory _logger;

        #endregion

        //POST
        #region create

        [HttpPost]
        [Route("create")]
        public virtual async Task<IActionResult> Create(TItem item)
        {
            var result = await _manager.AddAsync(item);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion

        //GET
        #region read list

        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> List()
        {
            var items = _manager.Items;
            return new ObjectResult(items);
        }

        #endregion

        //GET
        #region read single by id

        [HttpGet]
        [Route("single-id")]
        public virtual async Task<IActionResult> FindById([FromQuery]TKey id)
        {
            var items = await _manager.FindByIdAsync(id);
            return new ObjectResult(items);
        }

        #endregion

        //POST
        #region update

        [HttpPost]
        [Route("update")]
        public virtual async Task<IActionResult> Update(TItem item)
        {
            var result = await _manager.UpdateAsync(item);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion

        //POST
        #region delete

        [HttpPost]
        [Route("delete")]
        public virtual async Task<IActionResult> Delete(TItem item)
        {
            var result = await _manager.DeleteAsync(item);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion

        //POST
        #region delete by id

        [HttpPost]
        [Route("delete-id")]
        public virtual async Task<IActionResult> DeleteById([FromQuery]TKey id)
        {
            var result = await _manager.DeleteByIdAsync(id);
            if (result.Succeeded)
            {
                return new ObjectResult(true);
            }
            else
            {
                return new ObjectResult(false);
            }
        }

        #endregion
    }

    #region Shortcut class for Guid

    public abstract class PersistentItemController<TItem> : PersistentItemController<TItem, Guid>
    where TItem : class, IPersistentItem<Guid>
    {
        public PersistentItemController(IPersistentItemManager<TItem, Guid> manager) : base(manager) { }
    }

    #endregion
}
