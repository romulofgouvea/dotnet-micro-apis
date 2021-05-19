using Flunt.Notifications;
using Flunt.Validations;

namespace Api1.Domain.Entities
{
    public class InterestRates : Notifiable<Notification>
    {
        public InterestRates(double value)
        {
            Value = value;

            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterOrEqualsThan(value, 0, "Value", "O valor não pode ser vazio.")
            );
        }

        public double Value { get; private set; }
    }
}
