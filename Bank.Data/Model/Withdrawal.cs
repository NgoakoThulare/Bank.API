namespace Bank.Data.Model
{
    public class Withdrawal
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingBalance { get; set; }
    }
}
