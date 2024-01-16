using CbrAdapter.Database.Models;

namespace CbrAdapter.Database.Repositories
{
    public class KeyRateRepository : IKeyRateRepository
    {
        private readonly CbrAdapterDbContext _context;

        public KeyRateRepository(CbrAdapterDbContext context)
            => _context = context;

        public async Task Create(KeyRate keyRate)
        {
            await _context.AddAsync(keyRate);

            await _context.SaveChangesAsync();
        }
    }
}
