using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Resource;
using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Service
{
    public class ProvinceService: BaseService<Province>, IProvinceService
    {
        #region Declare
        IProvinceRepository _provinceRepository;
        ServiceResult _serviceResult;
        #endregion
        #region Contructor
        public ProvinceService(IBaseRepository<Province> baseRepository, IProvinceRepository provinceRepository) : base(baseRepository)
        {
            _provinceRepository = provinceRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region Methods
        public ServiceResult GetProvincetWithCountry(Guid CountryId)
        {
            var result = _provinceRepository.GetProvincetWithCountry(CountryId);
            if(result != null)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add(CustomResource.IsValid);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = result;
                return _serviceResult;
            }    
            else
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.Nocontent);
                _serviceResult.MISACode = Enums.MISACode.NoContent;
                _serviceResult.Data = result;
                return _serviceResult;
            }
        }
        #endregion
    }
}
