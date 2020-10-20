using System;
using System.Threading;
using Mocking.Common.Enums;
using Mocking.Common.Models;
using Mocking.Common.Services;

namespace Mocking.Services
{
    public class CreditCardProcessor: ICreditCardProcessor
    {
        public string ChargePayment(ICreditCard card, decimal amount)
        {
            Console.WriteLine("Simulating a call to the real processor.");
            Console.WriteLine("The credit card is being charged - this is a long process.");

            Thread.Sleep(5000);
            if(card.CardType == CardType.Amex && card.Number.Length != 15) throw new Exception("Invalid card number");

            return "111111111";
        }
    }
}