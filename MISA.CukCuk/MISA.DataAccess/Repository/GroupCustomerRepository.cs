using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class GroupCustomerRepository : BaseRepository<GroupCustomer>,IGroupCustomerRepository
    {
        public GroupCustomerRepository(IDatabaseContext<GroupCustomer> databaseContext) : base(databaseContext)
        {
        }
    }
}
