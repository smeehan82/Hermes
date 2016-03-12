using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Modules
{
    interface IModule
    {
        Guid Id { get; }
        string Name { get; }
        string Version { get; }
        string Description { get; }
        bool IsActive { get; set; }
        bool IsInstalled { get; set; }

        Task ActivateAsync();
        Task DeactivateAsync();
    }
}
