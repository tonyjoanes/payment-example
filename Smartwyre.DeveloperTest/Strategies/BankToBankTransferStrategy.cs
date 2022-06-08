namespace Smartwyre.DeveloperTest.Strategies
{
    using Smartwyre.DeveloperTest.Types;

    public class BankToBankTransferStrategy : IPaymentSchemeValidationStrategy
    {
        public PaymentScheme SupportedScheme => PaymentScheme.BankToBankTransfer;

        public bool ValidateScheme(Account account, decimal requestAmount = 0)
        {
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.BankToBankTransfer)
                ? true
                : false;
        }
    }
}
