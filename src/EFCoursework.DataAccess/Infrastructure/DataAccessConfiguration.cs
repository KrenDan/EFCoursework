using EFCoursework.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Infrastructure
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IModelRepository, ModelRepository>();

            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
