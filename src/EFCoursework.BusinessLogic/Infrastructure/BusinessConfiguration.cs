using EFCoursework.DataAccess.Infrastructure;
using EFCoursework.DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.BusinessLogic.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));

            //services.AddTransient<IModelService<Model>, ModelService>();

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}
