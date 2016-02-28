using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Hermes.Taxonomy.Tags
{
    public class TagManager
    {
        #region Constructor

        private TagStore _tagStore;
        private ILogger _logger;

        public TagManager(TagStore tagStore, ILoggerFactory loggerFactory)
        {
            _tagStore = tagStore;
            _logger = loggerFactory.CreateLogger<TagManager>();
        }

        #endregion

        #region Tag CRUD Operations

        public async Task AddTagAsync(Tag tag)
        {
            await _tagStore.AddAsync(tag);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var tags = _tagStore.Tags;
            return tags;
        }

        public async Task<Tag> FindTagAsync(Guid id)
        {
            var tag = await _tagStore.FindByIdAsync(id);
            return tag;
        }

        public async Task<Tag> FindTagAsync(string slug)
        {
            var tag = await _tagStore.FindBySlugAsync(slug);
            return tag;
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            await _tagStore.UpdateAsync(tag); ;
        }

        public async Task DeleteTagAsync(Guid id)
        {
            await _tagStore.DeleteByIdAsync(id);
        }

        public async Task DeleteTagAsync(Tag tag)
        {
            await _tagStore.DeleteAsync(tag);
        }

        #endregion
    }
}
