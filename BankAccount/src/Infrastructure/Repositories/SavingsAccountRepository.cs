using BankAccount.src.Domain.IServices;
using BankAccount.src.Domain.Models;

namespace BankAccount.src.Infrastructure.Repositories
{
    public class SavingsAccountRepository : ISavingsAccountRepository
    {
        private readonly SavingsAccount _savingsAccount;

        public SavingsAccountRepository(SavingsAccount savingsAccount)
        {
            _savingsAccount = savingsAccount ?? throw new ArgumentNullException(nameof(savingsAccount));
        }

        public void Deposit(decimal amount)
        {
            if (_savingsAccount.Solde + amount > _savingsAccount.MaxDeposit) 
            {
                throw new InvalidOperationException("Vous avez dépassé votre plafond de dépôt autorisée !");
            }
            _savingsAccount.Solde += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (_savingsAccount.BankOverdraftAmount > 0)
            {
                throw new InvalidOperationException("Il n'y a pas d'autorisation de découvert bancaire sur un compte d'épargne!");
            }
            if (_savingsAccount.Solde - amount < 0)
            {
                throw new InvalidOperationException("Retrait non autorisé, solde insuffisant!");
            }

            _savingsAccount.Solde -= amount;
        }
    }
}
