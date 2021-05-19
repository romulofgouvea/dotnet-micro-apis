using Api2.Application.Models;

namespace Api2.Application.Repositories
{
    public interface IServiceCalculateInterestRates : IService
    {
        decimal CalculateCompoundInterest(MCompoundInterest compoundInterest);
    }
}
