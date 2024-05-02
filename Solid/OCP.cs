using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class OCP
    {
        public class PaymentProcessor
        {
            public void ProcessPayment(IPaymentType paymentMethod, double amount)
            {
                paymentMethod.ProcessPayment(amount);
            }
        }

        public interface IPaymentType
        {
            void ProcessPayment(double amount);
        }
        public class CreditCardPayment : IPaymentType
        {
            public void ProcessPayment(double amount)
            {
                Console.WriteLine(amount.ToString());
            }
        }
        public class PayPalPayment : IPaymentType
        {
            public void ProcessPayment(double amount)
            {
                Console.WriteLine(amount.ToString());
            }
        }
        public class BankTransferPayment : IPaymentType
        {
            public void ProcessPayment(double amount)
            {
                Console.WriteLine(amount.ToString());
            }
        }

    }
}
