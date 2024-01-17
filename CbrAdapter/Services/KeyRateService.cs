using AutoMapper;
using CbrAdapter.Database.Repositories;
using CbrAdapter.Models;

namespace CbrAdapter.Services
{
    public class KeyRateService : IKeyRateService
    {
        private readonly IKeyRateRepository _keyRateRepository;
        private readonly IMapper _mapper;

        public KeyRateService(IKeyRateRepository keyRateRepository, IMapper mapper)
        {
            _keyRateRepository = keyRateRepository;
            _mapper = mapper;
        }

        public async Task CreateKeyRates(ICollection<KeyRate> keyRates)
        {
            await _keyRateRepository.CreateKeyRates(_mapper.Map<List<Database.Models.KeyRate>>(keyRates));
        }
    }
}
