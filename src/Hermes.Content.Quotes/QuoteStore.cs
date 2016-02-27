using Hermes.DataAccess;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Quotes
{
    public class QuoteStore : ContentStore<Quote>, IQuoteStore
    {
        #region Contructor

        public QuoteStore(IDataContext context, ILoggerFactory loggerFactory) : base(context)
        {
            _logger = loggerFactory.CreateLogger<QuoteStore>();
        }

        #endregion

        public IQueryable<Quote> Quotes { get { return Items; } }
    }
}
