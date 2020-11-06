﻿using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
    {
       
        public  EmployeeRepository(IDatabaseContext<Employee> databaseContext) : base(databaseContext)
        {
            
        }
        public bool CheckEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseContext.Get("Proc_GetEmployeeByCode", employeeCode);
            if (objectValue == null)
                return false;
            else
                return true;
        }
    }
}
