using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public interface IPage<TKey> : IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        //ITemplate PageTemplate { get; set; }
        //IPageContent PageContent { get; set; }
        //ICollection<IWidget> PageWidgets { get; set; }
        string Name { get; set; }
        string Path { get; set; }
    }

    public interface IPage : IPage<Guid> { }
}
