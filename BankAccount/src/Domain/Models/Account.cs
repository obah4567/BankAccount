namespace BankAccount.src.Domain.Models
{
    public class Account
    {        
        public string AccountNumber { get; set; }
        public decimal Solde { get; set; }
        public decimal BankOverdraftAmount { get; set; }

        public string AccountType { get; set; }
        public List<Transactions> _transactions;    

        public Account(string accountNumber, decimal solde, decimal bankOverdraftAmount = 0)
        {
            AccountNumber = accountNumber;
            Solde = solde;
            BankOverdraftAmount = bankOverdraftAmount;
            AccountType = "Compte Courant";
            _transactions = new List<Transactions>();
        }

        public void ConfigureAccount(string accountType)
        {
            if (string.IsNullOrWhiteSpace(accountType))
                throw new ArgumentException("Account type cannot be empty.");
            AccountType = accountType;
        }

    }
}
