namespace Smartwyre.DeveloperTest.Data
{
    using Smartwyre.DeveloperTest.Types;
    using System.Linq;

    public class AccountDataStore : IAccountDataStore
    {
        readonly AccountDbContext dbContext;

        public AccountDataStore(AccountDbContext dbContext)
        {
            this.dbContext = dbContext;
            SeedData();
        }

        public AccountDbContext DbContext { get; }

        public Account GetAccount(string accountNumber)
        {
            var account = this.dbContext.Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

            // Access database to retrieve account, code removed for brevity 
            return account;
        }

        public void UpdateAccount(Account account)
        {
            // We could do this in a transaction if not using InMemory store
            // using var transaction = this.dbContext.Database.BeginTransaction();

            try
            {
                //transaction.CreateSavepoint("UpdateAccount");

                this.dbContext.Accounts.Update(account);
                this.dbContext.SaveChanges();

                //transaction.Commit();
            }
            catch (System.Exception)
            {
                //transaction.RollbackToSavepoint("UpdateAccount");
                throw;

                // we could perhaps add some retry mechanisms etc
            }
        }

        private void SeedData()
        {
            this.dbContext.Accounts.Add(new Account
            {
                Id = 1,
                AccountNumber = "D123",
                Balance = 1000,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.AutomatedPaymentSystem
            });

            this.dbContext.Accounts.Add(new Account
            {
                Id = 2,
                AccountNumber = "666",
                Balance = 1000,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.BankToBankTransfer
            });

            this.dbContext.Accounts.Add(new Account
            {
                Id = 3,
                AccountNumber = "H43634",
                Balance = 1000,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.ExpeditedPayments
            });

            this.dbContext.SaveChanges();
        }
    }
}
