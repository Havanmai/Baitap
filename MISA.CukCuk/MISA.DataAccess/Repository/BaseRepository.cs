using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected IDatabaseContext<T> _databaseContext;
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public int Delete(Guid id)
        {
            return _databaseContext.DeleteId(id);
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        

        public string GetbyCode()
        {
            return _databaseContext.GetbyCode();
        }

        public T GetById(Guid objectId)
        {
            return _databaseContext.GetById(objectId);
        }

        public int Insert(T entity)
        {
            return _databaseContext.Insert(entity);
        }

        public int Update(T entity, Guid objectId)
        {
            return _databaseContext.Update(entity,objectId);
        }
        public object Get(string storeName, string code)
        {
            return _databaseContext.Get(storeName, code);
        }
    }
}
