namespace BankAccount.src.Domain.Models
{
    public class Transactions
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        
        public Transactions(DateTime date, decimal amount, string description)
        {
            Date = date;
            Amount = amount;
            Description = description;
        }
    }
}
