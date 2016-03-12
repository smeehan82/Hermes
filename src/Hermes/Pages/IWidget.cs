using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public interface IWidget<TKey> : IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        Guid PageId { get; set; }
        string Paramaters { get; set; }
    }

    public interface IWidget : IWidget<Guid> { }
}
