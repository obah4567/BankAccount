using BankAccount.src.Domain.Models;

namespace BankAccount.src.Domain.IServices
{
    public interface ITransactionRepository
    {
        public void AddTransaction(Transactions transaction);
        public List<Transactions> GetTransactions();

        public void MoneyDeposit(decimal amount);

        public void MoneyWithdrawal(decimal amount);
    }
}
