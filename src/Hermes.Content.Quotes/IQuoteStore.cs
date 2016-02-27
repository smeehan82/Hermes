using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Content.Quotes
{
    interface IQuoteStore : IContentStore<Quote, Guid>
    {
        IQueryable<Quote> Quotes { get; }
    }
}
