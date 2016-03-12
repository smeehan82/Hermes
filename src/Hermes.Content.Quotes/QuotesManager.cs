using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Hermes.DataAccess;
using Microsoft.AspNet.Http;

namespace Hermes.Content.Quotes
{
    public interface IQuoteManager : IContentManager<Quote, Guid>
    {
        IQueryable<Quote> Quote { get; }
    }

    public class QuoteManager : ContentManager<Quote, Guid>, IQuoteManager
    {
        #region Constructor

        private ILogger _logger;

        public QuoteManager(IQuoteStore store, IHttpContextAccessor contextAccessor, ILoggerFactory loggerFactory) : base(store, contextAccessor)
        {
            _logger = loggerFactory.CreateLogger<QuoteManager>();
        }

        #endregion

        public IQueryable<Quote> Quote { get { return _store.Items; } }
    }
}
