namespace OrderProcessing
{
    public interface IPaymentService
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
    }
}