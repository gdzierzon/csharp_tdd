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
            // use the factory pattern to create a default processor
            processor = CreditCardProcessorFactory.Processor;
        }

        public Invoice(ICreditCardProcessor processor)
        {
            // allow for processor injection
            this.processor = processor;
        }

        public string ChargeCard(decimal amount, ICreditCard card)
        {
            var authorization = processor.ChargePayment(card, amount);

            return authorization;
        }
    }
}