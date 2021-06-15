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
            if(result != null)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = result;
                return _serviceResult;
            }    
            else
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add("Không có dữ liệu");
                _serviceResult.MISACode = Enums.MISACode.NoContent;
                _serviceResult.Data = result;
                return _serviceResult;
            }
        }
        #endregion
    }
}
