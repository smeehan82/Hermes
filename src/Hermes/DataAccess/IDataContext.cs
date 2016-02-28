using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IDataContext
    {
        IQueryable<TModel> Set<TModel>() where TModel : class;
        void Add<TModel>(TModel model) where TModel : class;
        Task SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
        void Delete<TModel>(TModel model) where TModel : class;
        void Delete<TModel>(Guid id) where TModel : class, IContent;
        void DeleteTaxonomy<TModel>(Guid id) where TModel : class, ITaxonomy;
        void Update<TModel>(TModel model) where TModel : class;
        EntityEntry Attach(object entity, GraphBehavior behavior = GraphBehavior.IncludeDependents);
    }
}
