using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IPersistentItem<TKey> where TKey: IEquatable<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IPersistentItem : IPersistentItem<Guid> {}
}