using Mocking.Common.Enums;
using Mocking.Common.Models;

namespace Mocking.Common.Services
{
    public interface ICreditCardProcessor
    {
        string ChargePayment(ICreditCard card, decimal amount);
    }
}