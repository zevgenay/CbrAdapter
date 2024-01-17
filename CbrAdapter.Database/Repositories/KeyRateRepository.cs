using CbrAdapter.Database.Models;

namespace CbrAdapter.Database.Repositories
{
    public class KeyRateRepository : IKeyRateRepository
    {
        private readonly CbrAdapterDbContext _context;

        public KeyRateRepository(CbrAdapterDbContext context)
            => _context = context;

        public async Task CreateKeyRates(ICollection<KeyRate> keyRates)
        {
            await _context.AddRangeAsync(keyRates);

            await _context.SaveChangesAsync();
        }
    }
}
