using Api2.Application.Models;
using Api2.Application.Repositories;
using System;

namespace Api2.Application.Services
{
    public class CalculateInterestRatesService : IServiceCalculateInterestRates
    {
        public decimal CalculateCompoundInterest(MCompoundInterest compoundInterest)
        {
            if (!compoundInterest.Valid())
            {
                return 0;
            }

            var calcPow = Math.Pow((1 + compoundInterest.Tax), compoundInterest.Mounths);

            return compoundInterest.InicialValue * Convert.ToDecimal(calcPow);
        }
    }
}
