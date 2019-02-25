using System.Collections.Generic;
using System.Reflection;

namespace Newbe.Claptrap.Abstract.Assemblies
{
    public interface IActorAssemblyProvider
    {
        IEnumerable<Assembly> GetAssemblies();
    }
}