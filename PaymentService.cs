using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class PaymentService : IPaymentService
    {
        public Dictionary<string, decimal> validCreditCardNumbers;
        public PaymentService()
        {
            validCreditCardNumbers = new Dictionary<string, decimal>();
            validCreditCardNumbers.Add("1234567812345678", 300);
            validCreditCardNumbers.Add("4567123445671234", 1000);
            validCreditCardNumbers.Add("3456009933441234", 10);             
        }
        
        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            if (validCreditCardNumbers.ContainsKey(creditCardNumber) && validCreditCardNumbers[creditCardNumber] >= amount)
            {
                validCreditCardNumbers[creditCardNumber] -= amount;
                return true;
            }
            return false;
        }        

    }
}
