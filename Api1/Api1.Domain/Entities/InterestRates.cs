namespace Api1.Domain.Entities
{
    public class InterestRates
    {
        public InterestRates(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }
    }
}
