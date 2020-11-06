using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class DepartmentRepository:BaseRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository (IDatabaseContext<Department> databaseContext) : base(databaseContext)
        {

        }
    }
}
