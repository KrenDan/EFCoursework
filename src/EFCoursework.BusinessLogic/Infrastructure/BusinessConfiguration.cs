﻿using EFCoursework.BusinessLogic.Services;
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
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessConfiguration.ConfigureServices(services, configuration);

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient<IGameService, GameService>();

            return services;
        }
    }
}