using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class GroupCustomer
    {
        public GroupCustomer()
        {
            GroupCustomerId = Guid.NewGuid();
        }
        public Guid GroupCustomerId { get; set; }
        public string GroupCustomerCode { get; set; }
        public string GroupCustomerName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDay { get; set; }
        public string ModifiedBy { get; set; }
    }
}
