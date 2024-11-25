using BankAccount.src.Domain.IServices;
using BankAccount.src.Domain.Models;

namespace BankAccount.src.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public void MoneyDeposit(Account account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            account.Solde += amount;
        }

        public void MoneyWithdrawal(Account money, decimal amount)
        {
            if (money == null) 
            {
                throw new ArgumentNullException(nameof(money));
            }
            if (amount <= 0) 
            {
                throw new ArgumentException("Le montant demander doit être positif");
            }
            if (amount > money.Solde) 
            {
                throw new Exception("Vous n'avez pas suffisamment de solde dans votre compte pour valider ce retrait");
            }
            money.Solde -= amount;
        }

        public void MoneyWithdrawalWithOverdraftAuthorization(Account money, decimal amount)
        {
            if (money == null)
            {
                throw new ArgumentNullException(nameof(money));
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Le montant demander doit être positif");
            }
            if (money.Solde - amount < -money.BankOverdraftAmount)
            {
                throw new InvalidOperationException("Vous avez dépassé le montant autorisé pour votre découvert !");
            }
            money.Solde -= amount;
        }
    }
}
