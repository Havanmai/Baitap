using MISA.Common.Models;
using MISA.DataAccess.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interface
{
    public interface IDBGroupCustomer
    {
        IEnumerable<GroupCustomer> Get();
    }
}
