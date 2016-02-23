using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IDataContext
    {
        IQueryable<TModel> Set<TModel>() where TModel : class;
        void Create<TModel>(TModel model) where TModel : class;
        Task SaveAsync();
        void Delete<TModel>(TModel model) where TModel : class;
        void Delete<TModel>(Guid id) where TModel : class, IContent;
        void DeleteTaxonomy<TModel>(Guid id) where TModel : class, ITaxonomy;
        void Update<TModel>(TModel model) where TModel : class;
    }
}
