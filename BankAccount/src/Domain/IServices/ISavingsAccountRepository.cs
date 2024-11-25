namespace BankAccount.src.Domain.IServices
{
    public interface ISavingsAccountRepository
    {
        public void Deposit(decimal amount);

        public void Withdraw(decimal amount);
    }
}
