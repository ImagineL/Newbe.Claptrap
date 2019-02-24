using System.Reflection;
using Newbe.Claptrap.Abstract.Assemblies;

namespace Newbe.Claptrap.Autofac
{
    public class ActorAssemblyProvider : IActorAssemblyProvider
    {
        private readonly Assembly _assembly;

        public ActorAssemblyProvider(
            Assembly assembly)
        {
            _assembly = assembly;
        }

        public Assembly GetAssembly()
        {
            return _assembly;
        }
    }
}