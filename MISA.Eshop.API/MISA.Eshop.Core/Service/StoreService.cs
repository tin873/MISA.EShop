using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Resource;
using MISA.Eshop.Core.Result;

namespace MISA.Eshop.Core.Service
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        #region Declare
        IStoreRepository _storeRepository;
        ServiceResult _serviceResult;
        #endregion
        #region Contructor
        public StoreService(IBaseRepository<Store> baseRepository, IStoreRepository storeRepository): base(baseRepository)
        {
            _storeRepository = storeRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region Methods
        public ServiceResult GetPaging(int pageSize, int pageIndex)
        {
            int totalPage, totalRecord;
            var stores = _storeRepository.GetPaging( pageSize,  pageIndex, out totalPage, out totalRecord);
            if(stores != null)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add(CustomResource.IsValid);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = stores;
                _serviceResult.TotalPage = totalPage;
                _serviceResult.TotalRecord = totalRecord;
                return _serviceResult;
            }
            else
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.Nocontent);
                _serviceResult.MISACode = Enums.MISACode.NoContent;
                _serviceResult.Data = stores;
                _serviceResult.TotalPage = totalPage;
                _serviceResult.TotalRecord = totalRecord;
                return _serviceResult;
            }
        }

        public ServiceResult GetStoreFilter(string storeCode,
            string storeName, string address, string phoneNumber, int? status)
        {
            var stores = _storeRepository.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
            if(stores != null)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add(CustomResource.IsValid);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = stores;
                return _serviceResult;
            }
            else
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.Nocontent);
                _serviceResult.MISACode = Enums.MISACode.NoContent;
                _serviceResult.Data = stores;
                return _serviceResult;
            }
        }

        public ServiceResult CheckStoreCodeExits(string storeCode)
        {
            var result = _storeRepository.CheckStoreCodeExits(storeCode);
            if(result)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add(CustomResource.CodeNocontent);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = result;
                return _serviceResult;
            } 
            else
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add(CustomResource.ExitsCode);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = result;
                return _serviceResult;
            }    
        }

        public ServiceResult GetStoreFilterPaging(string storeCode, 
            string storeName, string address, string phoneNumber,
            int? status, int pageSize, int pageIndex)
        {
            int totalPage, totalRecord ;
            var stores = _storeRepository.GetStoreFilterPaging(storeCode, storeName, address, 
                phoneNumber, status, pageSize, pageIndex, out totalPage, out totalRecord);
            if(stores != null)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.UserMsg.Add(CustomResource.IsValid);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Data = stores;
                _serviceResult.TotalPage = totalPage;
                _serviceResult.TotalRecord = totalRecord;
                return _serviceResult;
            }    
            else
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.Nocontent);
                _serviceResult.MISACode = Enums.MISACode.NoContent;
                _serviceResult.Data = stores;
                _serviceResult.TotalPage = totalPage;
                _serviceResult.TotalRecord = totalRecord;
                return _serviceResult;
            }    
        }
        #endregion
    }
}
