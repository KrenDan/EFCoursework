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
            services.AddTransient<IRepository<Developer>, BaseRepository<Developer>>();
            services.AddTransient<IRepository<Game>, BaseRepository<Game>>();
            services.AddTransient<IRepository<GameDeveloper>, BaseRepository<GameDeveloper>>();
            services.AddTransient<IRepository<GameGenre>, BaseRepository<GameGenre>>();
            services.AddTransient<IRepository<GameLanguage>, BaseRepository<GameLanguage>>();
            services.AddTransient<IRepository<GamePublisher>, BaseRepository<GamePublisher>>();
            services.AddTransient<IRepository<GameSystem>, BaseRepository<GameSystem>>();
            services.AddTransient<IRepository<GameTag>, BaseRepository<GameTag>>();
            services.AddTransient<IRepository<Genre>, BaseRepository<Genre>>();
            services.AddTransient<IRepository<Image>, BaseRepository<Image>>();
            services.AddTransient<IRepository<Language>, BaseRepository<Language>>();
            services.AddTransient<IRepository<OS>, BaseRepository<OS>>();
            services.AddTransient<IRepository<Publisher>, BaseRepository<Publisher>>();
            services.AddTransient<IRepository<Tag>, BaseRepository<Tag>>();
            services.AddTransient<IRepository<Video>, BaseRepository<Video>>();

            services.AddDbContext<ApplicationContext>(builder => 
                builder.UseSqlServer(configuration.GetConnectionString("AzureConnection")));

            return services;
        }
    }
}
