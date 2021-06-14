using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Service
{
    public class ProviceService: BaseService<Province>, IProviceService
    {
        #region Declare
        IProvinceRepository _provinceRepository;
        ServiceResult _serviceResult;
        #endregion
        #region Contructor
        public ProviceService(IBaseRepository<Province> baseRepository, IProvinceRepository provinceRepository) : base(baseRepository)
        {
            _provinceRepository = provinceRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region Methods
        public ServiceResult GetProvincetWithCountry(Guid CountryId)
        {
            var result = _provinceRepository.GetProvincetWithCountry(CountryId);
            _serviceResult.IsSuccess = true;
            _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
            _serviceResult.Data = result;
            return _serviceResult;
        }
        #endregion
    }
}
