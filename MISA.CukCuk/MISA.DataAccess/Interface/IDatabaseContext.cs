using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interface
{
    public interface IDatabaseContext<T>
    {
        IEnumerable<T> Get();
        T GetById(object id);
        int Insert(T entity);
        int Update(T entity, object id);
        int DeleteId(object id);
        IEnumerable<T> Get(string storeName);
        object Get(string storeName, string code);
        string GetbyCode();
    }
}
