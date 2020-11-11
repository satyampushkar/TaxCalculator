using System.Threading.Tasks;

namespace TaxCalculator.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}