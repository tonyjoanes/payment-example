namespace Smartwyre.DeveloperTest.Tests
{
    using Smartwyre.DeveloperTest.Strategies;
    using Smartwyre.DeveloperTest.Tests.Helpers;
    using Smartwyre.DeveloperTest.Types;
    using Xunit;

    public class AutomatedPaymentSystemStrategyTests
    {
        [Fact]
        public void LiveAccount_With_AutomatedPaymentSystem_Returns_true()
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.AutomatedPaymentSystem)
                .WithStatus(AccountStatus.Live)
                .Build();

            var sut = new AutomatedPaymentSystemStrategy();

            var result = sut.ValidateScheme(account);

            Assert.True(result);
        }

        [Fact]
        public void DisabledAccount_With_AutomatedPaymentSystem_Scheme_Returns_False()
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.AutomatedPaymentSystem)
                .WithStatus(AccountStatus.Disabled)
                .Build();

            var sut = new AutomatedPaymentSystemStrategy();

            var result = sut.ValidateScheme(account);

            Assert.False(result);
        }

        [Fact]
        public void InboundPaymentsOnlyAccount_With_AutomatedPaymentSystem_Scheme_Returns_False()
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.AutomatedPaymentSystem)
                .WithStatus(AccountStatus.InboundPaymentsOnly)
                .Build();

            var sut = new AutomatedPaymentSystemStrategy();

            var result = sut.ValidateScheme(account);

            Assert.False(result);
        }
    }
}
