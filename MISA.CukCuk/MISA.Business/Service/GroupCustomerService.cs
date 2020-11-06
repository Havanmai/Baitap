using MISA.Business.Interface;
using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Business.Service
{
    public class GroupCustomerService : BaseService<GroupCustomer>
    {
        IGroupCustomerService _groupCustomerService;
        public GroupCustomerService(IGroupCustomerRepository groupCustomerRepository) : base(groupCustomerRepository)
        {
            
        }
        
    }
}
