using Hermes.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Hermes.Taxonomy.Tags
{
    public class TagStore
    {
        #region Contructor

        private IDataContext _context;
        private ILogger _logger;

        public TagStore(IDataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<TagStore>();
        }

        #endregion

        #region CRUD Operations

        public async Task AddTagAsync(Tag tag)
        {
            _context.Create(tag);
            await _context.SaveAsync();
        }

        public virtual IQueryable<Tag> Tags
        {
            get { return _context.Set<Tag>(); }
        }

        public async Task<Tag> FindTagAsync(Guid id)
        {
            return await Tags.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tag> FindTagAsync(string slug)
        {
            return await Tags.Where(b => b.Slug == slug).FirstOrDefaultAsync();
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            _context.Update(tag);
            await _context.SaveAsync();
        }

        public async Task DeleteTagAsync(Guid id)
        {
            throw new NotImplementedException("This message was not implemented");
        }

        public async Task DeleteTagAsync(Tag tag)
        {
            _context.Delete(tag);
            await _context.SaveAsync();
        }

        #endregion
    }
}
