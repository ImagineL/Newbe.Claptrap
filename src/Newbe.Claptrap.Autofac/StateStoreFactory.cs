using System.Collections.Generic;
using Newbe.Claptrap.Abstract;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateStore;
using Newbe.Claptrap.StateStore.Memory;

namespace Newbe.Claptrap.Autofac
{
    public class StateStoreFactory : IStateStoreFactory
    {
        private readonly IDictionary<string, IStateStore> _dictionary = new Dictionary<string, IStateStore>();

        public IStateStore Create(IActorIdentity identity)
        {
            // todo this is not impl
            if (!_dictionary.TryGetValue(identity.Id, out var store))
            {
                store = new MemoryStateStore(identity);
                _dictionary.Add(identity.Id, store);
            }

            return store;
        }
    }
}