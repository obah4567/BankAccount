namespace BankAccount.src.Domain.Models
{
    public class SavingsAccount : Account
    {
        public decimal MaxDeposit { get; set; }

        public SavingsAccount(string accountNumber, decimal solde, decimal bankOverdraftAmount, decimal maxDeposit) : base(accountNumber, solde, bankOverdraftAmount)
        {
            MaxDeposit = maxDeposit;
        }
    }
}
