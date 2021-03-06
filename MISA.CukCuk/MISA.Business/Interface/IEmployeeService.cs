﻿using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Interface
{
    public interface IEmployeeService:IBaseService<Employee>
    {

        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true: có; false: không</returns>
        /// CreatedBy: HVM
        bool CheckEmployeeByCode(string employeeCode);
    }
}
