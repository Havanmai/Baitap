using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.Common.Models.Enumeration;
using System.Resources;
using MISA.Common.Properties;

namespace MISA.Common.Models
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string GenderName
        {
            get
            {
                if (Gender == null)
                    return "Không xác định";
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

        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public DateTime  IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public string IdentityID { get; set; }
        public string TaxCode { get; set; }
        public Guid PositionID { get; set; }
        public Guid DepartmentID { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public double Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public int? WorkStatus { get; set; }
        public string WorkStatusName
        {
            get
            {
                if (WorkStatus == null)
                    return string.Empty;
                switch ((WorkStatus)WorkStatus)
                {

                    case Enumeration.WorkStatus.Stopped:
                        return ResourceVN.Enum_WorkStatus_Stopped;
                    case Enumeration.WorkStatus.Working:
                        return ResourceVN.Enum_WorkStatus_Working;
                    case Enumeration.WorkStatus.Waiting:
                        return ResourceVN.Enum_WorkStatus_Waitiing;
                    default:
                        return string.Empty;
                }
            }
        }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime  ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
