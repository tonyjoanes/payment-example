namespace Smartwyre.DeveloperTest.Strategies
{
    using Smartwyre.DeveloperTest.Types;

    public class ExpeditedPaymentsStrategy : IPaymentSchemeValidationStrategy
    {
        public PaymentScheme SupportedScheme => PaymentScheme.ExpeditedPayments;

        public bool ValidateScheme(Account account, decimal requestAmount = 0)
        {
            if (account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.ExpeditedPayments))
            {
                return account.Balance < requestAmount
                    ? false
                    : true;
            }

            return false;
        }
    }
}
