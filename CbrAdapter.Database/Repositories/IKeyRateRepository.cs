using CbrAdapter.Database.Models;

namespace CbrAdapter.Database.Repositories
{
    public interface IKeyRateRepository
    {
        public Task CreateKeyRates(ICollection<KeyRate> keyRates);
    }
}
