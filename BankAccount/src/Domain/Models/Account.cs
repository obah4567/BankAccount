namespace BankAccount.src.Domain.Models
{
    public class Account
    {        
        public string AccountNumber { get; set; }
        public decimal Solde { get; set; }
        public decimal BankOverdraftAmount { get; set; }


        public Account(string accountNumber, decimal solde)
        {
            AccountNumber = accountNumber;
            Solde = solde;
            BankOverdraftAmount = 0;
        }

        public Account(string accountNumber, decimal solde, decimal bankOverdraftAmount = 0)
        {
            AccountNumber = accountNumber;
            Solde = solde;
            BankOverdraftAmount = bankOverdraftAmount;
        }
    }
}
