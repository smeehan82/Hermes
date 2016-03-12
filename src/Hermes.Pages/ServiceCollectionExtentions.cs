using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Hermes.DataAccess;

namespace Hermes.Pages
{
    public static class ServiceCollectionExtentions
    {
        public static void AddPages(this IServiceCollection services, DataContextBuilder dataContextBuilder)
        {
            services.AddScoped<IPageStore, PageStore>();
            services.AddScoped<IPageManager, PageManager>();

            dataContextBuilder.RegisterModel<Page>();
            dataContextBuilder.RegisterModel<PlainTextPageContent>();
        }
    }
}
