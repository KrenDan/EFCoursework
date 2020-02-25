using EFCoursework.DataAccess.Context;
using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.Repositories;
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
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRepository<Developer>, GenericRepository<Developer>>();
            services.AddTransient<IRepository<Game>, GenericRepository<Game>>();
            services.AddTransient<IRepository<GameDeveloper>, GenericRepository<GameDeveloper>>();
            services.AddTransient<IRepository<GameGenre>, GenericRepository<GameGenre>>();
            services.AddTransient<IRepository<GameLanguage>, GenericRepository<GameLanguage>>();
            services.AddTransient<IRepository<GamePublisher>, GenericRepository<GamePublisher>>();
            services.AddTransient<IRepository<GameSystem>, GenericRepository<GameSystem>>();
            services.AddTransient<IRepository<GameTag>, GenericRepository<GameTag>>();
            services.AddTransient<IRepository<Genre>, GenericRepository<Genre>>();
            services.AddTransient<IRepository<Image>, GenericRepository<Image>>();
            services.AddTransient<IRepository<Language>, GenericRepository<Language>>();
            services.AddTransient<IRepository<OS>, GenericRepository<OS>>();
            services.AddTransient<IRepository<Publisher>, GenericRepository<Publisher>>();
            services.AddTransient<IRepository<Tag>, GenericRepository<Tag>>();
            services.AddTransient<IRepository<Video>, GenericRepository<Video>>();

            services.AddDbContext<ApplicationContext>(builder => 
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
