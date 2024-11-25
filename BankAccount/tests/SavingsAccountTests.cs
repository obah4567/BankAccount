using BankAccount.src.Domain.IServices;
using BankAccount.src.Domain.Models;
using BankAccount.src.Infrastructure.Repositories;
using NUnit.Framework;

namespace BankAccount.tests
{
    public class SavingsAccountTests
    {
        private ISavingsAccountRepository _savingsAccountRepository;
        private SavingsAccount _savingsAccount;
        [SetUp]
        public void SetUp()
        {
            _savingsAccount = new SavingsAccount("Jean Doe", 200, 0, 500);
            _savingsAccountRepository = new SavingsAccountRepository(_savingsAccount);
        }

        #region Deposit
        [Test]
        public void Deposit_ShouldIncreaseBalance_WhenNotExceedingDepositLimit()
        {
            //Arrange
            //Act
            _savingsAccountRepository.Deposit(300);

            //Assert
            Assert.AreEqual(500, _savingsAccount.Solde);
        }

        [Test]
        public void Deposit_ShouldThrowException_WhenExceedingDepositLimit()
        {
            // Act et Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _savingsAccountRepository.Deposit(350));
            Assert.AreEqual("Vous avez dépassé votre plafond de dépôt autorisée !", exception.Message);
        }

        #endregion

        #region Withdraw
        [Test]
        public void Withdraw_ShouldDecreseBalance_WhenNotOverdraft()
        {
            //Arrange
            //Act
            _savingsAccountRepository.Withdraw(100);

            //Assert
            Assert.AreEqual(100, _savingsAccount.Solde);
        }

        [Test]
        public void Withdraw_ShouldThrowException_WhenAmountExceedsBalance()
        {
            // Act et Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _savingsAccountRepository.Withdraw(250));
            Assert.AreEqual("Retrait non autorisé, solde insuffisant!", exception.Message);
        }

        [Test]
        public void Withdraw_ShouldThrowException_WhenOverdraftIsConfiguredButNotAllowed()
        {
            // Arrange
            _savingsAccount.BankOverdraftAmount = 100;

            // Act et Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _savingsAccountRepository.Withdraw(250));
            Assert.AreEqual("Il n'y a pas d'autorisation de découvert bancaire sur un compte d'épargne!", exception.Message);
        }
        #endregion
    }
}
