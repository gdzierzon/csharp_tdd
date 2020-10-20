using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocking.Common.Enums;
using Mocking.Common.Models;
using Mocking.Common.Services;

namespace Mocking.Fakes
{
    public class CreditCardProcessorFake: ICreditCardProcessor
    {
        public string ChargePayment(ICreditCard card, decimal amount)
        {
            Console.WriteLine("Fake CC Call.");

            if (card.CardType == CardType.Amex && card.Number.Length != 15) throw new Exception("Invalid number for American Express");
            if ((card.CardType == CardType.Visa || card.CardType == CardType.MasterCard) && card.Number.Length != 16) throw new Exception("Invalid number for Visa or MasterCard");

            return "**555555**";
        }
    }
}
