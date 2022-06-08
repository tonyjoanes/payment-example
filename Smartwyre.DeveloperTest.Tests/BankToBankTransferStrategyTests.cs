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

    public class BankToBankTransferStrategyTests
    {
        [Fact]
        public void Account_With_BankToBankTransferScheme_Returns_true()
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.BankToBankTransfer)
                .Build();

            var sut = new BankToBankTransferStrategy();

            var result = sut.ValidateScheme(account);

            Assert.True(result);
        }

        [Fact]
        public void Account_With_AutomatedPaymentSystem_Scheme_Returns_False()
        {
            var account = new AccountBuilder()
                .WithPaymentScheme(AllowedPaymentSchemes.AutomatedPaymentSystem)
                .Build();

            var sut = new BankToBankTransferStrategy();

            var result = sut.ValidateScheme(account);

            Assert.False(result);
        }
    }
}
