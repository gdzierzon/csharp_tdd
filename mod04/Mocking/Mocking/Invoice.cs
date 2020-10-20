using Mocking.Common.Models;
using Mocking.Common.Services;
using Mocking.Factories;
using Mocking.Services;

namespace Mocking
{
    public class Invoice
    {
        private ICreditCardProcessor processor;

        public Invoice()
        {
            processor = new CreditCardProcessor();
        }

        public Invoice(ICreditCardProcessor processor)
        {
            this.processor = processor;
        }

        public string ChargeCard(decimal amount, ICreditCard card)
        {
            var authorization = processor.ChargePayment(card, amount);

            return authorization;
        }
    }
}