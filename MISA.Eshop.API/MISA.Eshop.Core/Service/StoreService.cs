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
        public ServiceResult GetPaging(int pageIndex, int pageSize)
        {
            var stores = _storeRepository.GetPaging(pageIndex, pageSize);
            _serviceResult.IsSuccess = true;
            _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
            _serviceResult.Data = stores;
            return _serviceResult;
        }

        public ServiceResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            var stores = _storeRepository.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
            _serviceResult.IsSuccess = true;
            _serviceResult.UserMsg.Add("Lấy dữ liệu thành công.");
            _serviceResult.Data = stores;
            return _serviceResult;
        }
        #endregion
    }
}
