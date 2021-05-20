using Api2.Application.Repositories;
using Flunt.Notifications;
using Flunt.Validations;

namespace Api2.Application.Models
{
    public class MCompoundInterest : Notifiable<Notification>, IModel
    {
        public decimal InicialValue { get; set; }
        public double Tax { get; set; }
        public int Mounths { get; set; }

        public bool Valid()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(InicialValue, 0, "InicialValue", "O valor inicial não pode ser negativo.")
                .IsLowerOrEqualsThan(Tax, 0, "Tax", "O taxa de juros não pode ser negativo.")
                .IsGreaterThan(Mounths, 0, "Mounths", "O mes deve ser maior que zero.");

            AddNotifications(contract);

            return IsValid;
        }
    }
}
