using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interface
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HVM (17/10/2020)
        IEnumerable<T> Get();
        T GetById(Guid objectId);
        int Insert(T entity);
        int Update(T entity, Guid id);
        int Delete(Guid id);
        string GetbyCode();
        object Get(string storeName, string code);

    }
}
