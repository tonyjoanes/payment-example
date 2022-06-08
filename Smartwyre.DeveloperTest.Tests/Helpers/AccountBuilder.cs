namespace Smartwyre.DeveloperTest.Tests.Helpers
{
    using Smartwyre.DeveloperTest.Types;

    public class AccountBuilder
    {
        private Account account;

        public AccountBuilder()
        {
            this.account = new Account
            {
                Id = 1,
                AccountNumber = "TEST1234",
                Balance = 100,
                Status = AccountStatus.Live,
                AllowedPaymentSchemes = AllowedPaymentSchemes.AutomatedPaymentSystem
            };
        }

        public AccountBuilder WithBalance(decimal balance)
        {
            this.account.Balance = balance;
            return this;
        }
        public AccountBuilder WithPaymentScheme(AllowedPaymentSchemes scheme)
        {
            this.account.AllowedPaymentSchemes = scheme;
            return this;
        }

        public AccountBuilder WithStatus(AccountStatus status)
        {
            this.account.Status = status;
            return this;
        }

        public Account Build()
        {
            return this.account;
        }
    }
}
