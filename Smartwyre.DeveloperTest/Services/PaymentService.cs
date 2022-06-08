namespace Smartwyre.DeveloperTest.Services
{
    using Smartwyre.DeveloperTest.Data;
    using Smartwyre.DeveloperTest.Strategies;
    using Smartwyre.DeveloperTest.Types;

    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore accountDataStor;
        private readonly IPaymentSchemeValidationStrategyFactory paymentSchemeValidationStrategyFactory;

        public PaymentService(
            IAccountDataStore accountDataStor, 
            IPaymentSchemeValidationStrategyFactory paymentSchemeValidationStrategyFactory)
        {
            this.accountDataStor = accountDataStor;
            this.paymentSchemeValidationStrategyFactory = paymentSchemeValidationStrategyFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Account account = this.accountDataStor.GetAccount(request.DebtorAccountNumber);
            
            var result = new MakePaymentResult();

            if (account == null)
            {
                result.Success = false;
                return result;
            }

            var paymentSchemeStrategy = this.paymentSchemeValidationStrategyFactory.GetSchemeValidationStrategy(request.PaymentScheme);

            result.Success = paymentSchemeStrategy.ValidateScheme(account);

            if (result.Success)
            {
                account.Balance -= request.Amount;

                this.accountDataStor.UpdateAccount(account);
            }

            return result;
        }
    }
}
