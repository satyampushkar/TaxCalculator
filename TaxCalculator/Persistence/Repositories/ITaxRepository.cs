using TaxCalculator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaxCalculator.Persistence.Repositories
{
    public interface ITaxRepository
    {
        Task AddAsync(Tax tax);
        Task AddRangeAsync(IEnumerable<Tax> taxes);
        Task<IEnumerable<Tax>> ListAsync();
        void Update(Tax tax);
    }
}