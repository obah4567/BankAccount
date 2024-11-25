﻿using BankAccount.src.Domain.IServices;
using BankAccount.src.Domain.Models;
using BankAccount.src.Infrastructure.Repositories;
using NUnit.Framework;
using System;

namespace BankAccount.tests
{
    [TestFixture]
    public class AccountTests
    {
        private IAccountRepository _accountRepository;

        [SetUp]
        public void SetUp()
        {
            _accountRepository = new AccountRepository();
        }

        [Test]
        public void Deposit_ShouldIncreaseBalance()
        {
            //Arrange
            var account = new Account("Jean Doe", 15);

            //Act 
            _accountRepository.MoneyDeposit(account, 100);

            //Assert
            Assert.AreEqual(115, account.Solde);
        }

        [Test]
        public void Deposit_NullAccount_ShouldThrowArgumentNullException()
        {
            //Arrange

            //Act et //Assert
            Assert.Throws<ArgumentNullException>(() => _accountRepository.MoneyDeposit(null, 100));
        }

        [Test]
        public void Withdrawal_ShouldDecreaseBalance()
        {
            //Arrange
            var account = new Account("Jean Doe", 150);

            //Act 
            _accountRepository.MoneyWithdrawal(account, 100);

            //Assert
            Assert.AreEqual(50, account.Solde);
        }

        [Test]
        public void Withdrawal_InsufficientFunds_ShouldThrowException()
        {
            // Arrange
            var account = new Account("Jean Doe", 15);

            // Act & Assert
            var excep = Assert.Throws<Exception>(() => _accountRepository.MoneyWithdrawal(account, 100));
            Assert.AreEqual("Vous n'avez pas suffisamment de solde dans votre compte pour valider ce retrait", excep.Message);
        }
    }
}