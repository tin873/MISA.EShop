using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
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
            int totalPage = 0, totalRecord = 0;
            var stores = _storeRepository.GetPaging( pageSize,  pageIndex, out totalPage, out totalRecord);
            _serviceResult.IsSuccess = true;
            _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
            _serviceResult.MISACode = Enums.MISACode.Success;
            _serviceResult.Data = stores;
            _serviceResult.TotalPage = totalPage;
            _serviceResult.TotalRecord = totalRecord;
            return _serviceResult;
        }

        public ServiceResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            var stores = _storeRepository.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
            _serviceResult.IsSuccess = true;
            _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
            _serviceResult.MISACode = Enums.MISACode.Success;
            _serviceResult.Data = stores;
            return _serviceResult;
        }
        #endregion
    }
}
