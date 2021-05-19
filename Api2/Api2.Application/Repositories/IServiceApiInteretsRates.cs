namespace Api2.Application.Repositories
{
    public interface IServiceApiInterestsRates : IService
    {
        double FindValueInterestRates(string urlBaseApi);
    }
}
