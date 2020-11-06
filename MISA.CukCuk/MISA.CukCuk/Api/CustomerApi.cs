using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.Common.Models;
using MISA.DataAccess;
using MISA.Business.Interface;
using MISA.Business.Service;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApi : BaseApi<Customer>
    {
        

        
         public CustomerApi(IBaseService<Customer> customerService):base(customerService)
        {
           
        }
        
    }
}
