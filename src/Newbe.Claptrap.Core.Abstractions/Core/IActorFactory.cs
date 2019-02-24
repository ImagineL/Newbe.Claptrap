namespace Newbe.Claptrap.Abstract.Core
{
    public interface IActorFactory
    {
        IActor Create(IActorIdentity identity);
    }
}