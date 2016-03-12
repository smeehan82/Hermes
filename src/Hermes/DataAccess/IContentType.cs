using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public interface IContentType
    {
        Guid Id { get; set; }
        string ContentName { get; set; }
        Guid ModuleId { get; set; }        
    }
}
