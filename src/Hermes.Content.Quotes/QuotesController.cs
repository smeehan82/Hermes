using Hermes.DataAccess;
using Hermes.Mvc;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Quotes
{
    [Route("api/quotes")]
    public class QuoteController : ContentController<Quote, Guid>
    {
        #region Contructor

        public QuoteController(QuoteManager manager) : base(manager)
        {
            _manager = manager;
        }

        new protected QuoteManager _manager;

        #endregion

        //POST
        #region create

        [HttpPost]
        [Route("create-title")]
        public virtual async Task<IActionResult> Create([FromQuery]string title)
        {
            var quote = new Quote();

            quote.Title = title;
            quote.DateCreated = DateTimeOffset.Now;
            quote.DateModified = DateTimeOffset.Now;
            quote.DatePublished = DateTimeOffset.Now;
            quote.Content = "";

            var result = await _manager.AddAsync(quote);
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
