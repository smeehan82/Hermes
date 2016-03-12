using Hermes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public class Page : IPage, IPersistentItem
    {
        public string ConcurrencyStamp { get; set; }
        public Guid Id { get; set; }
        //public IPageContent PageContent { get; set; }
        //public ITemplate PageTemplate { get; set; }
        //public ICollection<IWidget> PageWidgets { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}
