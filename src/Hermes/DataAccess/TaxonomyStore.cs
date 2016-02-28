using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public abstract class TaxonomyStore<TTaxonomy, TKey> : PersistentItemStore<TTaxonomy, TKey>, ITaxonomyStore<TTaxonomy, TKey>
        where TTaxonomy : class, ITaxonomy<TKey>
        where TKey : IEquatable<TKey>
    {
        public TaxonomyStore(IDataContext context) : base(context) { }

        public async Task<TTaxonomy> FindBySlugAsync(string slug, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Items.FirstOrDefaultAsync(c => c.Slug.Equals(slug));
        }
    }

    public abstract class TaxonomyStore<TTaxonomy> : TaxonomyStore<TTaxonomy, Guid>
        where TTaxonomy : class, ITaxonomy<Guid>
    {
        public TaxonomyStore(IDataContext context) : base(context) { }

        public override Task<Guid> GenerateKeyAsync()
        {
            return Task.FromResult(Guid.NewGuid());
        }
    }
}
