using BankAccount.src.Domain.IServices;
using BankAccount.src.Domain.Models;

namespace BankAccount.src.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Account account;

        public TransactionRepository(Account _account)
        {
            account = _account ?? throw new ArgumentNullException(nameof(account));
        }

        public void AddTransaction(Transactions transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            account._transactions.Add(transaction);
        }

        public List<Transactions> GetTransactions()
        {
            return account._transactions;
        }

        public void MoneyDeposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Le depot doit être positive");
            }
            account.Solde += amount;
            AddTransaction(new Transactions(date: DateTime.UtcNow, amount, "Depot"));
        }

        public void MoneyWithdrawal(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Le retrait doit être positive.");

            if (account.Solde - amount < -account.BankOverdraftAmount)
                throw new InvalidOperationException("Le retrait ne doit pas dépasser le découvert autoriser");

            account.Solde -= amount;
            AddTransaction(new Transactions(DateTime.Now, -amount, "Retrait"));
        }

    }
}
