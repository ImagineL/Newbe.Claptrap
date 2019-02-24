using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Demo.Models
{
    public class AccountStateData : IStateData
    {
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
    }
}