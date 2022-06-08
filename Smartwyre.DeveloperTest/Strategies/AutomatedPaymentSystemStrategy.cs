namespace Smartwyre.DeveloperTest.Strategies
{
    using Smartwyre.DeveloperTest.Types;

    public class AutomatedPaymentSystemStrategy : IPaymentSchemeValidationStrategy
    {
        public PaymentScheme SupportedScheme => PaymentScheme.AutomatedPaymentSystem;

        public bool ValidateScheme(Account account, decimal requestAmount = 0)
        {
            if (account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.AutomatedPaymentSystem))
            {
                return account.Status != AccountStatus.Live
                    ? false
                    : true;
            }

            return false;
        }
    }
}
