using Dapper;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Eshop.Infrastructure.Repository
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public IEnumerable<Province> GetProvincetWithCountry(Guid CountryId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", CountryId.ToString());

            //thực hiện lấy dữ liệu
            var provices = _dbConnection.Query<Province>("Proc_GetProvinceWithCountry",
                param: dynamicParameters,
                commandType: CommandType.StoredProcedure);
            return provices;
        }
    }
}
