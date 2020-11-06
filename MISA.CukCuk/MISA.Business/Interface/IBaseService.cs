using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Interface
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HVM(15/10/2020)
        IEnumerable<T> Get();

        T GetById(Guid objectId);
        ServiceResponse Insert(T entity);
        int Update(T entity, Guid id);
        int Delete(Guid id);
        string GetbyCode();
    }
}
