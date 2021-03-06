using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Resource;
using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        IBaseRepository<T> _baseRepository;
        ServiceResult _serviceResult;
        #endregion
        #region Contructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region Methods
        public virtual ServiceResult Delete(Guid entityId)
        {
            try
            {
                var result = _baseRepository.Delete(entityId);
                if (result > 0)
                {
                    _serviceResult.IsSuccess = true;
                    _serviceResult.Data = result;
                    _serviceResult.UserMsg.Add(CustomResource.DeleteIsValid);
                    _serviceResult.MISACode = Enums.MISACode.Success;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.IsSuccess = false;
                    _serviceResult.Data = result;
                    _serviceResult.UserMsg.Add(CustomResource.StoreNocontent);
                    _serviceResult.MISACode = Enums.MISACode.NoContent;
                    return _serviceResult;
                }
            }
            catch (Exception)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.ErrorMISA);
                _serviceResult.MISACode = Enums.MISACode.Exeption;
                return _serviceResult;
            }  
        }

        public virtual ServiceResult GetById(Guid entityId)
        {
            try
            {
                var entity = _baseRepository.GetById(entityId);
                if (entity == null)
                {
                    _serviceResult.IsSuccess = false;
                    _serviceResult.Data = entity;
                    _serviceResult.UserMsg.Add(CustomResource.StoreNocontent);
                    _serviceResult.MISACode = Enums.MISACode.NoContent;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.IsSuccess = true;
                    _serviceResult.Data = entity;
                    _serviceResult.UserMsg.Add(CustomResource.IsValid);
                    _serviceResult.MISACode = Enums.MISACode.Success;
                    return _serviceResult;
                }
            }
            catch (Exception)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.ErrorMISA);
                _serviceResult.MISACode = Enums.MISACode.Exeption;
                return _serviceResult;
            }   
        }

        public virtual ServiceResult GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            if(entities != null)
            {
                _serviceResult.IsSuccess = true;
                _serviceResult.Data = entities;
                _serviceResult.UserMsg.Add(CustomResource.IsValid);
                _serviceResult.MISACode = Enums.MISACode.Success;
                return _serviceResult;
            }
            else
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.Data = entities;
                _serviceResult.UserMsg.Add(CustomResource.Nocontent);
                _serviceResult.MISACode = Enums.MISACode.NoContent;
                return _serviceResult;
            }
        }

        public virtual ServiceResult Insert(T entity)
        {
            try
            {
                var validateResult = ValidateObject(entity);
                if (validateResult == true)
                {
                    var result = _baseRepository.Insert(entity);
                    _serviceResult.IsSuccess = true;
                    _serviceResult.UserMsg.Add(CustomResource.AddIsValid);
                    _serviceResult.MISACode = Enums.MISACode.Success;
                    _serviceResult.Data = result;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.IsSuccess = false;
                    _serviceResult.Data = null;
                    _serviceResult.MISACode = Enums.MISACode.NotValid;
                    return _serviceResult;
                }
            }
            catch (Exception)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.ErrorMISA);
                _serviceResult.MISACode = Enums.MISACode.Exeption;
                return _serviceResult;
            }   
        }

        public virtual ServiceResult Update(T entity, Guid entityId)
        {
            try
            {
                var validateResult = ValidateObject(entity);
                if (validateResult == true)
                {
                    var result = _baseRepository.Update(entity, entityId);
                    _serviceResult.IsSuccess = true;
                    _serviceResult.UserMsg.Add(CustomResource.EditIsValid);
                    _serviceResult.Data = result;
                    _serviceResult.MISACode = Enums.MISACode.Success;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.IsSuccess = false;
                    _serviceResult.Data = null;
                    _serviceResult.MISACode = Enums.MISACode.NotValid;
                    return _serviceResult;
                }
            }
            catch (Exception)
            {
                _serviceResult.IsSuccess = false;
                _serviceResult.UserMsg.Add(CustomResource.ErrorMISA);
                _serviceResult.MISACode = Enums.MISACode.Exeption;
                return _serviceResult;
            }
        }
        /// <summary>
        /// validate thông tin người dùng nhập vào
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <returns>trả về true false</returns>
        /// createdBy: ndtin(22/6/2021)
        private bool ValidateObject(T entity)
        {
            //lấy ra danh sách properties của thực thể
            var properties = typeof(T).GetProperties();
            //duyệt từng property
            foreach (var property in properties)
            {
                //lấy giá trị của property
                var propertyValue = property.GetValue(entity);
                //lấy ra tên của property
                var propertyName = property.Name;
                //lấy các property có attribute là Required
                var propertyRequireds = property.GetCustomAttributes(typeof(Required), true);
                //lấy các property có attribute là MaxLength
                var propertyMaxLengths = property.GetCustomAttributes(typeof(MaxLength), true);

                //xử lý các property có attribute là Required
                if(propertyRequireds.Length > 0)
                {
                    if(propertyValue == null)
                    {
                        _serviceResult.UserMsg.Add($"{CustomResource.NotValue} {propertyName}");
                    }
                    //lấy ra custom message:
                    var userMsg = (propertyRequireds[0] as Required).CustomMsg;
                    //xử lý custom mesage
                    if(string.IsNullOrEmpty(userMsg))
                    {
                        //xử lý value property = isnullorempty
                        userMsg = $"{propertyName}";
                        if(string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            _serviceResult.UserMsg.Add($"{CustomResource.NotEmpty} {userMsg}");
                        }    
                    }
                    else
                    {
                        //xử lý value property = isnullorempty
                        if (string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            _serviceResult.UserMsg.Add(userMsg);
                        }
                    }    
                }
                //xử lý độ dài vượt quá số ký tự cho phép
                if(propertyMaxLengths.Length > 0)
                {
                    //lấy ra custom mesage
                    var userMsg = (propertyMaxLengths[0] as MaxLength).CustomMsg;
                    //lấy ra độ dài tối đa cho phép
                    var maxLength = (propertyMaxLengths[0] as MaxLength).Length;
                    //xử lý custom mesage
                    if(string.IsNullOrEmpty(userMsg))
                    {
                        if(propertyValue != null && propertyValue.ToString().Length > maxLength)
                        {
                            _serviceResult.UserMsg.Add(CustomResource.MaxLengthError);
                        }    
                    }  
                    else
                    {
                        if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                        {
                            _serviceResult.UserMsg.Add(userMsg);
                        }
                    }    
                }    
            }
            //xử lý trả về khi có thông báo lỗi 
            if(_serviceResult.UserMsg.Count > 0)
            {
                return false;
            }    
            else
            {
                return true;
            }    
        }
        #endregion
    }
}
