using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Hermes.DataAccess;

namespace Hermes.Taxonomy.Tags
{
    public static class ServiceCollectionExtentions
    {
        public static void AddBlogs(this IServiceCollection services, DataContextBuilder dataContextBuilder)
        {
            services.AddScoped<TagStore, TagStore>();

            dataContextBuilder.RegisterModel<Tag>();
        }
    }
}
