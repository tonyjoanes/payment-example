namespace Smartwyre.DeveloperTest.Tests
{
    using Smartwyre.DeveloperTest.Strategies;
    using Smartwyre.DeveloperTest.Tests.Helpers;
    using Smartwyre.DeveloperTest.Types;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ExpeditedPaymentsStrategyStrategyTests
    {
        private readonly ExpeditedPaymentsStrategy sut;

        public ExpeditedPaymentsStrategyStrategyTests()
        {
            this.sut = new ExpeditedPaymentsStrategy();
        }

        [Theory]
        [InlineData(100, 50)]
        [InlineData(150000, 100000)]
        [InlineData(2, 1)]
        [InlineData(99, 80)]
        [InlineData(5.0, 3.2)]
        public void AdequateBalanceAccount_With_ExpeditedPaymentsScheme_Returns_true(decimal balance, decimal requestAmount)
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.ExpeditedPayments)
                .WithBalance(balance)
                .Build();

            var result = sut.ValidateScheme(account, requestAmount);

            Assert.True(result);
        }

        [Theory]
        [InlineData(50, 100)]
        [InlineData(100000, 150000)]
        [InlineData(1, 2)]
        [InlineData(80, 99)]
        [InlineData(3.2, 5.2)]
        public void InadequateBalanceAccount_With_ExpeditedPaymentsScheme_Returns_true(decimal balance, decimal requestAmount)
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.ExpeditedPayments)
                .WithBalance(balance)
                .Build();

            var result = sut.ValidateScheme(account, requestAmount);

            Assert.False(result);
        }

        [Fact]
        public void Account_Without_AllowedExpeditedPayments_Returns_False()
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.AutomatedPaymentSystem)
                .WithBalance(500)
                .Build();

            var result = sut.ValidateScheme(account, 100);

            Assert.False(result);
        }
    }
}
