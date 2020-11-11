using TaxCalculator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaxCalculator.Persistence.Services
{
    public interface ITaxService
    {
        Task SaveAsync(IEnumerable<Tax> taxes);
        Task SaveAsync(Tax tax);
        Task<Tax> Search(string municipality, DateTime date);
    }
}