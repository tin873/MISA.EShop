using Dapper;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.Eshop.Infrastructure.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public bool CheckStoreCodeExits(string storeCode)
        {
            //thực thi câu lệnh lấy bản ghi bằng storeCode
            var sqlCommand = "SELECT * FROM Store WHERE StoreCode = @storeCode";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@storeCode", storeCode);
            //lấy ra bản ghi với mã code người dùng truyền vào
            var store = _dbConnection.Query<Store>(sqlCommand, param: dynamicParameters);
            //kiểm tra xem có bản ghi nào không
            if(store.Count() >= 1)
            {
                return true;
            }    
            else
            {
                return false;
            }    
        }

        public IEnumerable<Store> GetPaging(int pageSize, int pageIndex, out int totalPage, out int totalRecord)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageIndex", pageIndex);
            dynamicParameters.Add("@PageSize", pageSize);

            //mapping 2 biến out trong procedure
            dynamicParameters.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);
            dynamicParameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //thực thi lấy dữ liệu phân trang
            var stores = _dbConnection.Query<Store>($"Proc_GetStorePaging", 
                param: dynamicParameters, 
                commandType: CommandType.StoredProcedure);
            //lấy giá trị của biến out trong storeprocedure
            totalPage = dynamicParameters.Get<int>("@TotalPage");
            totalRecord = dynamicParameters.Get<int>("@TotalRecord");

            return stores;
        }

        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StoreCode", storeCode);
            dynamicParameters.Add("@StoreName", storeName);
            dynamicParameters.Add("@Address", address);
            dynamicParameters.Add("@PhoneNumber", phoneNumber);
            dynamicParameters.Add("@Status", status);

            var stores = _dbConnection.Query<Store>("Proc_GetStoreFilter",
                param: dynamicParameters,
                commandType: CommandType.StoredProcedure);

            return stores;
        }
    }
}
