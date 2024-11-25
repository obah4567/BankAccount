using BankAccount.src.Domain.Models;

namespace BankAccount.src.Domain.IServices
{
    public interface IAccountRepository
    {
        public void MoneyDeposit(Account account, decimal amount);

        public void MoneyWithdrawal(Account money, decimal amount);

        public void MoneyWithdrawalWithOverdraftAuthorization(Account money, decimal amount);
    }
}
