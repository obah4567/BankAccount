using BankAccount.src.Domain.IServices;
using BankAccount.src.Domain.Models;
using BankAccount.src.Infrastructure.Repositories;
using NUnit.Framework;

namespace BankAccount.tests
{
    [TestFixture]
    public class TransactionRepositoryTests
    {
        private ITransactionRepository _transactionRepository;
        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _account = new Account("Jean Doe", 100);
            _transactionRepository = new TransactionRepository(_account);
        }

        [Test]
        public void MoneyDeposit_ShouldIncreaseSoldeAndAddTransaction_WhenAmountIsValid()
        {
            // Act
            _transactionRepository.MoneyDeposit(50);

            // Assert
            Assert.AreEqual(150, _account.Solde);
            Assert.AreEqual(1, _account._transactions.Count);
            Assert.AreEqual(50, _account._transactions.First().Amount);
            Assert.AreEqual("Depot", _account._transactions.First().Description);
        }

        [Test]
        public void MoneyDeposit_ShouldThrowArgumentException_WhenAmountIsZeroOrNegative()
        {
            // Act et Assert
            Assert.Throws<ArgumentException>(() => _transactionRepository.MoneyDeposit(0));
            Assert.Throws<ArgumentException>(() => _transactionRepository.MoneyDeposit(-10));
        }

        [Test]
        public void MoneyWithdrawal_ShouldDecreaseSoldeAndAddTransaction_WhenAmountIsValid()
        {
            // Act
            _transactionRepository.MoneyWithdrawal(50);

            // Assert
            Assert.AreEqual(50, _account.Solde);
            Assert.AreEqual(1, _account._transactions.Count);
            Assert.AreEqual(-50, _account._transactions.First().Amount);
            Assert.AreEqual("Retrait", _account._transactions.First().Description);
        }

    }

}
