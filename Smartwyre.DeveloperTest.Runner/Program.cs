namespace Smartwyre.DeveloperTest.Runner
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Smartwyre.DeveloperTest.Data;
    using Smartwyre.DeveloperTest.Services;
    using Smartwyre.DeveloperTest.Strategies;
    using Smartwyre.DeveloperTest.Types;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var collection = ConfigureServices();
            var paymentService = collection.BuildServiceProvider().GetService<IPaymentService>();

            var paymentRequest = new MakePaymentRequest
            {
                Amount = 100,
                CreditorAccountNumber = "C123",
                DebtorAccountNumber = "D123",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.AutomatedPaymentSystem
            };

            var result = paymentService.MakePayment(paymentRequest);

            Console.WriteLine($"Payment was a ${result.Success}");
            Console.ReadLine();
        }

        static IServiceCollection ConfigureServices()
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IPaymentSchemeValidationStrategy, AutomatedPaymentSystemStrategy>();
            collection.AddScoped<IPaymentSchemeValidationStrategy, BankToBankTransferStrategy>();
            collection.AddScoped<IPaymentSchemeValidationStrategy, ExpeditedPaymentsStrategy>();
            collection.AddScoped<IPaymentService, PaymentService>();
            collection.AddScoped<IAccountDataStore, AccountDataStore>();
            collection.AddScoped<IPaymentSchemeValidationStrategyFactory, PaymentSchemeValidationStrategyFactory>();

            collection.AddDbContext<AccountDbContext>(options => options.UseInMemoryDatabase("AccountDb"));

            return collection;
        }
    }
}
