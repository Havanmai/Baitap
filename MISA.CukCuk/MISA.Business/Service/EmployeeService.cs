using MISA.Business.Interface;
using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Service
{
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool CheckEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode);
        }

        protected override bool Validate(Employee entity)
        {
            var isValid = true;
            // Check trùng mã:
            var isValidExitsCode = CheckEmployeeByCode(entity.EmployeeCode);
            if (isValidExitsCode)
            {
                isValid = false;
                validateErrorResponseMsg.Add("Mã bị trùng 1");
            }

            return isValid;
        }



    }
}
