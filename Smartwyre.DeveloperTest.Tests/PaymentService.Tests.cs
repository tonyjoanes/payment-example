namespace Smartwyre.DeveloperTest.Tests
{
    using NSubstitute;
    using Smartwyre.DeveloperTest.Data;
    using Smartwyre.DeveloperTest.Services;
    using Smartwyre.DeveloperTest.Strategies;
    using Smartwyre.DeveloperTest.Types;
    using Xunit;

    public class PaymentServiceTests
    {
        [Fact]
        public void Scheme_Is_BankToBankTransfer_And_Account_Null_Should_Return_Unsuccessful()
        {
            var mockAccountDataStore = Substitute.For<IAccountDataStore>();
            var mockPaymentSchemeValidationStrategyFactory = Substitute.For<IPaymentSchemeValidationStrategyFactory>();

            var paymentRequest = new MakePaymentRequest 
                { 
                    Amount = 0, 
                    CreditorAccountNumber = "A123", 
                    DebtorAccountNumber = "D999", 
                    PaymentDate = System.DateTime.Now, 
                    PaymentScheme = PaymentScheme.BankToBankTransfer 
            };

            var sut = new PaymentService(mockAccountDataStore, mockPaymentSchemeValidationStrategyFactory);

            var paymentResult = sut.MakePayment(paymentRequest);

            Assert.False(paymentResult.Success);
        }

        [Fact]
        public void Scheme_Is_AutomatedPaymentSystem_And_Account_Null_Should_Return_Unsuccessful()
        {
            var mockAccountDataStore = Substitute.For<IAccountDataStore>();
            var mockPaymentSchemeValidationStrategyFactory = Substitute.For<IPaymentSchemeValidationStrategyFactory>();

            var paymentRequest = new MakePaymentRequest
            {
                Amount = 0,
                CreditorAccountNumber = "A123",
                DebtorAccountNumber = "D999",
                PaymentDate = System.DateTime.Now,
                PaymentScheme = PaymentScheme.AutomatedPaymentSystem
            };

            var sut = new PaymentService(mockAccountDataStore, mockPaymentSchemeValidationStrategyFactory);

            var paymentResult = sut.MakePayment(paymentRequest);

            Assert.False(paymentResult.Success);
        }

        [Fact]
        public void Scheme_Is_ExpeditedPayments_And_Account_Null_Should_Return_Unsuccessful()
        {
            var mockAccountDataStore = Substitute.For<IAccountDataStore>();
            var mockPaymentSchemeValidationStrategyFactory = Substitute.For<IPaymentSchemeValidationStrategyFactory>();

            var paymentRequest = new MakePaymentRequest
            {
                Amount = 0,
                CreditorAccountNumber = "A123",
                DebtorAccountNumber = "D999",
                PaymentDate = System.DateTime.Now,
                PaymentScheme = PaymentScheme.ExpeditedPayments
            };

            var sut = new PaymentService(mockAccountDataStore, mockPaymentSchemeValidationStrategyFactory);

            var paymentResult = sut.MakePayment(paymentRequest);

            Assert.False(paymentResult.Success);
        }


    }
}
