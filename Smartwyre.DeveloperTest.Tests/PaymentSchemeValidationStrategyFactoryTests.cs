namespace Smartwyre.DeveloperTest.Tests
{
    using Smartwyre.DeveloperTest.Strategies;
    using System.Collections.Generic;
    using Xunit;

    public class PaymentSchemeValidationStrategyFactoryTests
    {
        private readonly IList<IPaymentSchemeValidationStrategy> strategyList;

        public PaymentSchemeValidationStrategyFactoryTests()
        {
            strategyList = new List<IPaymentSchemeValidationStrategy>();
            strategyList.Add(new AutomatedPaymentSystemStrategy());
            strategyList.Add(new ExpeditedPaymentsStrategy());
            strategyList.Add(new BankToBankTransferStrategy());
        }

        [Fact]
        public void Get_With_AutomatedPaymentScheme_Should_Return_AutomatedPaymentStrategy()
        {
            var sut = new PaymentSchemeValidationStrategyFactory(strategyList);

            var actual =  sut.GetSchemeValidationStrategy(Types.PaymentScheme.AutomatedPaymentSystem);

            Assert.IsType<AutomatedPaymentSystemStrategy>(actual);
        }

        [Fact]
        public void Get_With_ExpeditedPaymentsStrategy_Should_Return_AutomatedPaymentStrategy()
        {
            var sut = new PaymentSchemeValidationStrategyFactory(strategyList);

            var actual = sut.GetSchemeValidationStrategy(Types.PaymentScheme.ExpeditedPayments);

            Assert.IsType<ExpeditedPaymentsStrategy>(actual);
        }

        [Fact]
        public void Get_With_BankToBankTransferStrategy_Should_Return_BankToBankTransferStrategy()
        {
            var sut = new PaymentSchemeValidationStrategyFactory(strategyList);

            var actual = sut.GetSchemeValidationStrategy(Types.PaymentScheme.BankToBankTransfer);

            Assert.IsType<BankToBankTransferStrategy>(actual);
        }
    }
}
