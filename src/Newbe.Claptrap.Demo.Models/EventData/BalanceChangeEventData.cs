using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Demo.Models.EventData
{
    public class BalanceChangeEventData : IEventData
    {
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}