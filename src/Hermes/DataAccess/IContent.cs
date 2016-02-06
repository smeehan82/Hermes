using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IContent<TKey> : IPersistentItem<TKey>
        where TKey : IEquatable<TKey>
    {
        string Title { get; set; }
        string Slug { get; set; }
        //Guid OwnerId { get; set; }
        //Guid LastModifiedByUserId { get; set; }
        DateTimeOffset DateCreated { get; set; }
        DateTimeOffset DateModified { get; set; }
        DateTimeOffset DatePublished { get; set; }
    }

    public interface IContent : IContent<Guid> { }
}
