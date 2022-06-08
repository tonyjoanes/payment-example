namespace Smartwyre.DeveloperTest.Strategies
{
    using Smartwyre.DeveloperTest.Types;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentSchemeValidationStrategyFactory : IPaymentSchemeValidationStrategyFactory
    {
        private readonly IEnumerable<IPaymentSchemeValidationStrategy> strategies;

        public PaymentSchemeValidationStrategyFactory(IEnumerable<IPaymentSchemeValidationStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public IPaymentSchemeValidationStrategy GetSchemeValidationStrategy(PaymentScheme scheme)
        {
            var supportedStrategy = this.strategies.FirstOrDefault(x => x.SupportedScheme == scheme);

            return supportedStrategy;
        }
    }
}
