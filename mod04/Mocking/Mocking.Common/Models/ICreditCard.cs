using Mocking.Common.Enums;

namespace Mocking.Common.Models
{
    public interface ICreditCard
    {
        string Number { get; set; }
        string ExpirationMonth { get; set; }
        string ExpirationYear { get; set; }
        CardType CardType { get; set; }
        string Name { get; set; }

        string ExpirationDate { get; }

        string GetExpirationDate();
    }
}