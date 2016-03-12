using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Hermes.DataAccess;

namespace Hermes.Content.Blogs
{
    public static class ServiceCollectionExtentions
    {
        public static void AddBlogs(this IServiceCollection services, DataContextBuilder dataContextBuilder)
        {
            services.AddScoped<IBlogStore, BlogStore>();
            services.AddScoped<IBlogPostStore, BlogPostStore>();
            services.AddScoped<BlogManager, BlogManager>();

            dataContextBuilder.RegisterModel<Blog>();
            dataContextBuilder.RegisterModel<BlogPost>();
        }
    }
}
