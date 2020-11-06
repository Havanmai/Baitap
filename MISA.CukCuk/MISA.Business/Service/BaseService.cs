using MISA.Business.Interface;
using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        protected List<string> validateErrorResponseMsg = new List<string>();
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int Delete(Guid id)
        {
            return _baseRepository.Delete(id);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid objectId)
        {
            return _baseRepository.GetById(objectId);
        }

        public ServiceResponse Insert(T entity)
        {
            var serviceResponse = new ServiceResponse();
            if (Validate(entity) == true)
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
                serviceResponse.Data = _baseRepository.Insert(entity);
            }
            else
            {
                // các service trong nay deu tra 1 cai response, trong day co object, ket qua, va thong bao
                // Khi goi tu api vao thi no se tra ra du ca 3 cai
                // Minh se dựa vao thong bao de xem api minh dung ch cong hay khong
                // Cac api se truyen vao va tra ra duoi dang Json
                // Theo toi thì return se phai serilize no ve Json het(JsonConvert.Serilize)/ using Newston.Json 
                // Nhung ma neu no van chay dc thi oke, chac k can
                serviceResponse.Success = false;
                serviceResponse.Msg = validateErrorResponseMsg;
            }
            return serviceResponse;
        }

            public int Update(T entity, Guid objectId)
        {
            var affectRows = _baseRepository.Update(entity,objectId);
            return affectRows;
        }
        protected virtual bool Validate(T entity)
        {
            return true;
        }

        public string GetbyCode()
        {
            return  _baseRepository.GetbyCode();
           
        }
    }
}
