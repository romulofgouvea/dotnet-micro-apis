using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Application.Repositories
{
    public interface IServicesApiInterestsRates : IServices
    {
        double FindValueInterestRates(string urlBaseApi);
    }
}
