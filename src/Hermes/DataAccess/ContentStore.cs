using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public abstract class ContentStore<TContent, TKey> : PersistentItemStore<TContent, TKey>, IContentStore<TContent, TKey>
        where TContent : class, IContent<TKey>
        where TKey : IEquatable<TKey>
    {
        public ContentStore(IDataContext context) : base(context) { }

        public async Task<TContent> FindBySlugAsync(string slug, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Items.FirstOrDefaultAsync(c => c.Slug.Equals(slug));
        }
    }

    #region Class Definition with the key specified as a Guid

    public abstract class ContentStore<TContent> : ContentStore<TContent, Guid>
    where TContent : class, IContent<Guid>
    {
        public ContentStore(IDataContext context) : base(context) { }

        public override Task<Guid> GenerateKeyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(Guid.NewGuid());
        }
    }

    #endregion
}
