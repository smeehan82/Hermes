using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public class DataContextBuilder
    {
        public IList<Type> RegisteredModelTypes { get; } = new List<Type>();

        public void RegisterModel<T>() where T : IContent
        {
            RegisterModel(typeof(T));
        }

        public void RegisterModel(Type contentType)
        {
            if (!typeof(IContent).IsAssignableFrom(contentType))
            {
                throw new ArgumentException("Parameter should implement IContent", nameof(contentType));
            }

            RegisteredModelTypes.Add(contentType);
        }

        public void RegisterTaxonomyModel<T>() where T : ITaxonomy
        {
            RegisterTaxonomyModel(typeof(T));
        }

        public void RegisterTaxonomyModel(Type contentType)
        {
            if (!typeof(ITaxonomy).IsAssignableFrom(contentType))
            {
                throw new ArgumentException("Parameter should implement IContent", nameof(contentType));
            }

            RegisteredModelTypes.Add(contentType);
        }
    }
}
