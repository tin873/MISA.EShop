using Dapper;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Eshop.Infrastructure.Repository
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public IEnumerable<District> GetDistrictWithProvince(Guid ProvinceId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ProvinceId", ProvinceId.ToString());

            //thực hiện lấy dữ liệu
            var districts = _dbConnection.Query<District>("Proc_GetDistrictWithProvince",
                param: dynamicParameters,
                commandType: CommandType.StoredProcedure);
            return districts;
        }
    }
}
