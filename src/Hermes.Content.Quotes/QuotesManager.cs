using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Hermes.DataAccess;
using Microsoft.AspNet.Http;

namespace Hermes.Content.Quotes
{
    public class QuotesManager : ContentManager<Quote, Guid>
    {
        #region Constructor

        private ILogger _logger;

        public QuotesManager(IQuoteStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory) : base(store, contextAccessor)
        {
            _logger = loggerFactory.CreateLogger<QuotesManager>();
        }

        #endregion

        public IQueryable<Quote> Quotes { get { return _store.Items; } }
    }
}
