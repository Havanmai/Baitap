using Microsoft.Extensions.DependencyInjection;
using MISA.Business.Interface;
using MISA.Business.Service;
using MISA.DataAccess;
using MISA.DataAccess.DatabaseAccess;
using MISA.DataAccess.Interface;
using MISA.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk
{
    public class DIConfig
    {
        public static void InjectionConfig(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGroupCustomerRepository, GroupCustomerRepository>();
            //services.AddScoped<IGroupCustomerService, GroupCustomerService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IDatabaseContext<>), typeof(DatabaseContext<>));
        }
    }
}
