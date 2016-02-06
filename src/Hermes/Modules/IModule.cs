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

        Task ActivateAsync();
        Task DeactivateAsync();
    }
}
