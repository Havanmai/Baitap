using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Business.Interface;
using MISA.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentApi : BaseApi<Department>
    {
        public DepartmentApi(IBaseService<Department> baseApi):base(baseApi) 
        {

        }
    }
}
