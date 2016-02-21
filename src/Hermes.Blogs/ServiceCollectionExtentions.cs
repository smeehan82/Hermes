using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Hermes.DataAccess;

namespace Hermes.Blogs
{
    public static class ServiceCollectionExtentions
    {
        public static void AddBlogs(this IServiceCollection services, DataContextBuilder dataContextBuilder)
        {
            services.AddScoped<BlogStore, BlogStore>();
            services.AddScoped<BlogsManager, BlogsManager>();

            dataContextBuilder.RegisterModel<Blog>();
            dataContextBuilder.RegisterModel<BlogPost>();
        }
    }
}
