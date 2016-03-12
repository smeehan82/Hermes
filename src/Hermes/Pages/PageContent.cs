using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public abstract class PageContent : IPageContent
    {
        public string ConcurrencyStamp { get; set; }
        public Guid Id { get; set; }
        public IPage Page { get; set; }
        public Guid PageId { get; set; }
        public string Paramaters { get; set; }
    }
}
