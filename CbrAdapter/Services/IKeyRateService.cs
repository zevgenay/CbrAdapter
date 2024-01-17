using CbrAdapter.Models;

namespace CbrAdapter.Services
{
    public interface IKeyRateService
    {
        public Task CreateKeyRates(ICollection<KeyRate> keyRates);
    }
}
