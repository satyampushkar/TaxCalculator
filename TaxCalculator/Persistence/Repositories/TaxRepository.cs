using TaxCalculator.Models;
using TaxCalculator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Persistence.Repositories
{
    public class TaxRepository : BaseRepository, ITaxRepository
    {
        public TaxRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Tax>> ListAsync()
        {
            return await _context.Taxes.ToListAsync();
        }
        public async Task AddAsync(Tax tax)
        {
            await _context.Taxes.AddAsync(tax);
        }
        public async Task AddRangeAsync(IEnumerable<Tax> taxes)
        {
            await _context.Taxes.AddRangeAsync(taxes);
        }
        public void Update(Tax tax)
        {
            _context.Taxes.Update(tax);
        }
    }
}
