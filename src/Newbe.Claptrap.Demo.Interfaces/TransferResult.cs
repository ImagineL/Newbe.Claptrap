namespace Newbe.Claptrap.Demo.Interfaces
{
    public class TransferResult
    {
        public string? Error { get; set; }
        public decimal BalanceBefore { get; set; }
        public decimal BalanceNow { get; set; }
    }
}