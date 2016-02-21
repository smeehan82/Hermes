using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Hermes.DataAccess;

namespace Hermes.Quotes
{
    public static class ServiceCollectionExtentions
    {
        public static void AddQuotes(this IServiceCollection services, DataContextBuilder dataContextBuilder)
        {
            services.AddScoped<QuoteStore, QuoteStore>();
            services.AddScoped<QuotesManager, QuotesManager>();

            dataContextBuilder.RegisterModel<Quote>();
        }
    }
}
