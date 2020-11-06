using MISA.Business.Interface;
using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Service
{
    public class DepartmentService : BaseService<Department>,IDepartmentService

    {
        IDepartmentRepository _departmentRepository;
         public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}

