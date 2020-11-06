using MISA.Business.Interface;
using MISA.Common.Models;
using MISA.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        
         public CustomerService (ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
    }
}
