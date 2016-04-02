using Hermes.DataAccess;
using Hermes.Mvc;
using Hermes.Pages;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Web.Controllers
{
    [Route("api/pages")]
    public class PageController : PersistentItemController<Page, Guid>
    {
        #region Constructor

        public PageController(PageManager manager) : base(manager)
        {
            _manager = manager;
        }

        new protected PageManager _manager;

        #endregion

        //POST
        #region create

        [HttpPost]
        [Route("create-title")]
        public virtual async Task<IActionResult> Create([FromQuery]string title)
        {
            var page = new Page();

            page.Name = title;

            var result = await _manager.AddAsync(page);
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
}
