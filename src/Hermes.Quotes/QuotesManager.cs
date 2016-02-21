using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Hermes.Content.Quotes
{
    public class QuotesManager
    {
        #region Constructor

        private QuoteStore _quoteStore;
        private ILogger _logger;

        public QuotesManager(QuoteStore quoteStore, ILoggerFactory loggerFactory)
        {
            _quoteStore = quoteStore;
            _logger = loggerFactory.CreateLogger<QuotesManager>();
        }

        #endregion

        #region Quote CRUD Operations

        public async Task AddQuoteAsync(Quote quote)
        {
            await _quoteStore.AddQuoteAsync(quote);
        }

        public async Task<IEnumerable<Quote>> GetQuotesAsync()
        {
            var quotes = _quoteStore.Quotes;
            return quotes;
        }

        public async Task<Quote> FindQuoteAsync(Guid id)
        {
            var quote = await _quoteStore.FindQuoteAsync(id);
            return quote;
        }

        public async Task<Quote> FindQuoteAsync(string slug)
        {
            var quote = await _quoteStore.FindQuoteAsync(slug);
            return quote;
        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            await _quoteStore.UpdateQuoteAsync(quote); ;
        }

        public async Task DeleteQuoteAsync(Guid id)
        {
            await _quoteStore.DeleteQuoteAsync(id);
        }

        public async Task DeleteQuoteAsync(Quote quote)
        {
            await _quoteStore.DeleteQuoteAsync(quote);
        }

        #endregion
    }
}
