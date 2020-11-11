using TaxCalculator.Models;
using TaxCalculator.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TaxCalculator.Persistence.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TaxService(ITaxRepository taxRepository, IUnitOfWork unitOfWork)
        {
            _taxRepository = taxRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveAsync(Tax tax)
        {
            await _taxRepository.AddAsync(tax);
            await _unitOfWork.CompleteAsync();
        }
        public async Task SaveAsync(IEnumerable<Tax> taxes)
        {
            await _taxRepository.AddRangeAsync(taxes);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<Tax> Search(string municipality, DateTime date)
        {
            var taxes = await _taxRepository.ListAsync();
            var taxesForMunicipality = taxes
                .Where(tax => tax.Municipality == municipality)
                .OrderBy(tax => tax.TaxType);

            var tax = taxesForMunicipality.FirstOrDefault(tax => tax.StartDate.Date <= date.Date && date.Date <= tax.EndDate.Date);

            return tax;
        }
    }
}
