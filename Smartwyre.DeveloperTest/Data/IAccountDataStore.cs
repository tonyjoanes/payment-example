namespace Smartwyre.DeveloperTest.Data
{
    using Smartwyre.DeveloperTest.Types;

    public interface IAccountDataStore
    {
        Account GetAccount(string accountNumber);
        void UpdateAccount(Account account);
    }
}