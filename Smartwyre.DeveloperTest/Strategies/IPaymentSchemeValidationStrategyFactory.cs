namespace Smartwyre.DeveloperTest.Strategies
{
    using Smartwyre.DeveloperTest.Types;

    public interface IPaymentSchemeValidationStrategyFactory
    {
        IPaymentSchemeValidationStrategy GetSchemeValidationStrategy(PaymentScheme scheme);
    }
}
