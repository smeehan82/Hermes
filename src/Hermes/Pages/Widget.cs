using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Pages
{
    public abstract class Widget : IWidget
    {
        public string ConcurrencyStamp { get; set; }
        public Guid Id { get; set; }
        public Guid PageId { get; set; }
        public string Paramaters { get; set; }
    }
}
