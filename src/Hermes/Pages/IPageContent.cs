using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public interface IPageContent<TKey> : IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        //IPage Page { get; set; }
        Guid PageId { get; set; }
        string Paramaters { get; set; }
    }

    public interface IPageContent : IPageContent<Guid> { }
}
