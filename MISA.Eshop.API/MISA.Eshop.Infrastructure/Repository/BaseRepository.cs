using Dapper;
using MISA.Eshop.Core.Interfaces.IRepository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.Eshop.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable
    {
        #region Declare
        protected string _tableName = string.Empty;
        protected string _connectionString = "Host=47.241.69.179;" +
            "Port=3306;" +
            "User=nvmanh;" +
            "Password=12345678;" +
            "Database=MF835_TEST.MISA.eShop.copy";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public BaseRepository() 
        {
            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Methods
        public virtual int? Delete(Guid entityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeParamName, entityId.ToString());
            //thực hiện xóa dữ liệu trong bảng
            var result = _dbConnection.Execute($"Proc_Delete{_tableName}", 
                param: dynamicParameters, 
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public virtual T GetById(Guid entityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeParamName, entityId.ToString());
            //thực hiện lấy bản ghi trong bảng theo Id
            var entity = _dbConnection.Query<T>($"Proc_Get{_tableName}ById", 
                param: dynamicParameters, 
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return entity;
        }

        public virtual IEnumerable<T> GetEntities()
        {
            //thực hiện lấy tất cả các bản ghi trong bảng
            var entities = _dbConnection.Query<T>($"Proc_Get{_tableName}s",
                commandType: CommandType.StoredProcedure);

            return entities;
        }

        public virtual int? Insert(T entity)
        {
            var storeParameters = ParamDbType(entity);
            //thực hiện thêm mới 1 bản ghi vào bảng
            var result = _dbConnection.Execute($"Proc_Insert{_tableName}", param: 
                storeParameters, commandType:
                CommandType.StoredProcedure);

            return result;
        }

        public virtual int? Update(T entity, Guid entityId)
        {
            var storeParameters = ParamDbType(entity);
            storeParameters.Add($"@{_tableName}Id", entityId.ToString());
            //thực hiện Update 1 bản ghi
            var result = _dbConnection.Execute($"Proc_Update{_tableName}", param:
                storeParameters, commandType:
                CommandType.StoredProcedure);

            return result;
        }
        /// <summary>
        /// giải phóng tài nguyên chiếm giữ khi đối tượng bị hủy
        /// </summary>
        /// CreatedBy: ndtin(14/06/2021)
        public virtual void Dispose()
        {
            _dbConnection.Dispose();
        }


        /// <summary>
        /// Chuyển các biến trong thực thể về đúng kiểu dữ liệu và tạo dynamicPrameters
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>DynamicParameters</returns>
        /// CreatedBy: ndtin(14/06/2021)
        private DynamicParameters ParamDbType(T entity)
        {
            //lấy danh sách properties có trong thực thể
            var properties = entity.GetType().GetProperties();
            //khởi tạo dynamicParameters
            var parameters = new DynamicParameters();
            //duyệt từng properties
            foreach (var property in properties)
            {
                //lấy tên property
                var propertyName = property.Name;
                //lấy giá trị property
                var propertyValue = property.GetValue(entity);
                //lấy kiểu dữ liệu của property
                var propertyType = property.PropertyType;
                //so sánh kiểm tra kiểu dữ liệu của property và gán vào parameters
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyValue ? 1 : 0);
                         
                        parameters.Add($"@{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }

            }
            return parameters;
        }
        #endregion
    }
}
