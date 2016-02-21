using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using Hermes.DataAnnotations;

namespace Hermes.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        #region Constructor

        private DataContextBuilder _dataContextBuilder;
        private ILogger _logger;

        public DataContext(DataContextBuilder dataContextBuilder, ILoggerFactory loggerFactory)
        {
            _dataContextBuilder = dataContextBuilder;
            _logger = loggerFactory.CreateLogger<DataContext>();
        }

        #endregion

        #region CRUD Operations

        public void Create<TModel>(TModel model) where TModel : class
        {
            base.Add(model);
        }

        IQueryable<TModel> IDataContext.Set<TModel>()
        {
            return base.Set<TModel>();
        }

        public void Update<TModel>(TModel model) where TModel : class
        {
            base.Update(model);
        }

        public void Delete<TModel>(Guid id) where TModel : class, IContent
        {
            base.Set<TModel>().Where(tm=>tm.Id == id);
        }

        public void Delete<TModel>(TModel model) where TModel : class
        {
            base.Remove(model);
        }

        public async Task SaveAsync()
        {
            await base.SaveChangesAsync();
        }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var registeredModelType in _dataContextBuilder.RegisteredModelTypes)
            {
                var properties = registeredModelType.GetProperties(System.Reflection.BindingFlags.Public);

                builder.Entity(registeredModelType);

                foreach (var property in properties)
                {
                    var primaryKeyAttribute = property.GetCustomAttributes(false).Where(a => a is PrimaryKeyAttribute).SingleOrDefault();

                    if (primaryKeyAttribute != null)
                    {
                        builder.Entity(registeredModelType)
                            .HasKey(property.Name);
                    }
                }
            }
        }

        #endregion
    }
}
