using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;

namespace MISA.Eshop.Core.Service
{
    public class CountryService: BaseService<Country>, ICountryService
    {
        public CountryService(IBaseRepository<Country> baseRepository) : base(baseRepository)
        {
        }
    }
}
