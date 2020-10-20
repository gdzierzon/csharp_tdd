using Mocking.Common.Models;
using Mocking.Common.Services;
using Mocking.Factories;
using Mocking.Services;

namespace Mocking
{
    public class Invoice
    {
        public string ChargeCard(decimal amount, ICreditCard card)
        {
            CreditCardProcessor processor = new CreditCardProcessor();

            var authorization = processor.ChargePayment(card, amount);

            return authorization;
        }
    }
}