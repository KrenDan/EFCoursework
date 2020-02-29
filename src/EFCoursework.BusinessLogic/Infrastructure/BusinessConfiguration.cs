using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.BusinessLogic.Infrastructure.Mapper;
using EFCoursework.BusinessLogic.Services;
using EFCoursework.DataAccess.Infrastructure;
using EFCoursework.DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFCoursework.BusinessLogic.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessConfiguration.ConfigureServices(services, configuration);

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IParseService<IEnumerable<GameDTO>>, SteamParseService>();
        }
    }
}
