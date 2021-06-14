using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Service
{
    public class WardService : BaseService<Ward>, IWardService
    {
        #region Declare
        IWardRepository _wardRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Contructor
        public WardService(IBaseRepository<Ward> baseRepository, IWardRepository wardRepository) : base(baseRepository)
        {
            _wardRepository = wardRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Methods
        public ServiceResult GetWardWithDistrict(Guid DistrictId)
        {
            var result = _wardRepository.GetWardWithDistrict(DistrictId);
            _serviceResult.IsSuccess = true;
            _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
            _serviceResult.Data = result;
            return _serviceResult;
        }
        #endregion
    }
}
