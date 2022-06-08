namespace Smartwyre.DeveloperTest.Services
{
    using Smartwyre.DeveloperTest.Types;

    /// <summary>
    /// Interface for the Payment service
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Make a payment to the Payment Service.
        /// </summary>
        /// <param name="request">MakePaymentRequest</param>
        /// <returns>A MakePaymentResult.</returns>
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
