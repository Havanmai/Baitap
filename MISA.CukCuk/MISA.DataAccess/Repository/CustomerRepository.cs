using MISA.Common.Models;
using MISA.DataAccess.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{

    public class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext<Customer> databaseContext) : base(databaseContext)
        {
        }
      
    }
}
