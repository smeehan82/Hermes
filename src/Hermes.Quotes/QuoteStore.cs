using Hermes.DataAccess;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Quotes
{
    public class QuoteStore
    {
        #region Contructor

        private IDataContext _context;
        private ILogger _logger;

        public QuoteStore(IDataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<QuoteStore>();
        }

        #endregion

        #region CRUD Operations

        public async Task AddQuoteAsync(Quote quote)
        {
            _context.Create(quote);
            await _context.SaveAsync();
        }

        public virtual IQueryable<Quote> Quotes
        {
            get { return _context.Set<Quote>(); }
        }

        public async Task<Quote> FindQuoteAsync(Guid id)
        {
            return await Quotes.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Quote> FindQuoteAsync(string slug)
        {
            return await Quotes.Where(b => b.Slug == slug).FirstOrDefaultAsync();
        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            _context.Update(quote);
            await _context.SaveAsync();
        }

        public async Task DeleteQuoteAsync(Guid id)
        {
            _context.Delete<Quote>(id);
            await _context.SaveAsync();
        }

        public async Task DeleteQuoteAsync(Quote quote)
        {
            _context.Delete(quote);
            await _context.SaveAsync();
        }

        #endregion
    }
}
