namespace BankAccount.src.Domain.Models
{
    public class Account
    {        
        public string AccountNumber { get; set; }
        public decimal Solde { get; set; }


        public Account(string accountNumber, decimal solde)
        {
            AccountNumber = accountNumber;
            Solde = solde;
        }
    }
}
