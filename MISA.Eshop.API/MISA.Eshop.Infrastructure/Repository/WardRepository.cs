using Dapper;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Eshop.Infrastructure.Repository
{
    public class WardRepository : BaseRepository<Ward>, IWardRepository
    {
        public IEnumerable<Ward> GetWardWithDistrict(Guid DistrictId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DistrictId", DistrictId.ToString());

            //thực hiện lấy dữ liệu
            var wards = _dbConnection.Query<Ward>("Proc_GetProvinceWithCountry",
                param: dynamicParameters,
                commandType: CommandType.StoredProcedure);
            return wards;
        }
    }
}
