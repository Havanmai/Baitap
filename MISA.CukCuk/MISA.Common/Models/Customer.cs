using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string CustomerCompany { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0:
                        return "Nữ";
                    case 1:
                        return "Nam";
                    case 2:
                        return "Khác";
                    default:
                        return "Không xác định";


                }
            }
        }
        public string TaxCode { get; set; }
        public double? DebitAmount { get; set; }
        public DateTime? PostedDate { get; set; }
        public Guid?  CardClassId { get; set; }
        public string CardClassName { get; set; }
        public Guid? GroupCustomerId { get; set; }
        public string GroupCustomerName { get; set; }

    }
}
