using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public class DataContextBuilder
    {
        public IList<Type> RegisteredModelTypes { get; } = new List<Type>();

        public void RegisterModel<T>() where T : IPersistentItem
        {
            RegisterModel(typeof(T));
        }

        public void RegisterModel(Type modelType)
        {
            if (!typeof(IPersistentItem).IsAssignableFrom(modelType))
            {
                throw new ArgumentException("Parameter should implement IPersistentItem", nameof(modelType));
            }

            RegisteredModelTypes.Add(modelType);
        }
    }
}
