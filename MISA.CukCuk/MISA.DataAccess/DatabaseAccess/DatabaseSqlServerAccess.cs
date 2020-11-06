
using MISA.Common.Models;
using MISA.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccess
{
    
    public class DatabaseSqlServerAccess 
    {
        readonly string connectionString="";
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;
        public int DeleteId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
