namespace Smartwyre.DeveloperTest.Strategies
{
    using Smartwyre.DeveloperTest.Types;

    public interface IPaymentSchemeValidationStrategy
    {
        PaymentScheme SupportedScheme { get; }
        bool ValidateScheme(Account account, decimal amount = 0);
    }
}
