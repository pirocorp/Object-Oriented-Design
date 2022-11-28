namespace ChainOfResponsibility.Corporate
{
    public class Purchase
    {
        public Purchase(int number, decimal amount, string purpose)
        {
            Number = number;
            Amount = amount;
            Purpose = purpose;
        }

        public int Number { get; }

        public decimal Amount { get; }

        public string Purpose { get; }
    }
}
