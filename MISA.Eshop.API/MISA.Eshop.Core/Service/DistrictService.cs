using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Resource;
using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Service
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        #region Declare
        IDistrictRepository _districtRepository;
        ServiceResult _serviceResult;
        #endregion
        #region Contructor
        public DistrictService(IBaseRepository<District> baseRepository, IDistrictRepository districtRepository):base(baseRepository)
        {
            _districtRepository = districtRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region Methods
        public ServiceResult GetDistrictWithProvince(Guid ProvinceId)
        {
            var result = _districtRepository.GetDistrictWithProvince(ProvinceId);
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
