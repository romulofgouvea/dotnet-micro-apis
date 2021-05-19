using Api2.Application.Repositories;
using Flunt.Notifications;
using Flunt.Validations;

namespace Api2.Application.Models
{
    public class MInterestsRates : Notifiable<Notification>, IModel
    {
        public double Value { get; set; }

        public bool Valid()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Value, 0, "Value", "O valor não pode ser negativo.");

            AddNotifications(contract);

            return IsValid;
        }
    }
}
