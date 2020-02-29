using EFCoursework.DataAccess.Context;
using EFCoursework.DataAccess.Infrastructure;
using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(DbContext context, 
            IRepository<Game> games,
            IRepository<Developer> developers, 
            IRepository<GameDeveloper> gameDevelopers, 
            IRepository<GameGenre> gameGenres, 
            IRepository<GameLanguage> gameLanguages, 
            IRepository<GamePublisher> gamePublishers, 
            IRepository<GameSystem> gameSystems, 
            IRepository<GameTag> gameTags, 
            IRepository<Genre> genres, 
            IRepository<Image> images, 
            IRepository<Language> languages, 
            IRepository<OS> systems, 
            IRepository<Publisher> publishers, 
            IRepository<Tag> tags, 
            IRepository<Video> videos)
        {
            _context = context as ApplicationContext;
            Games = games;
            Developers = developers;
            GameDevelopers = gameDevelopers;
            GameGenres = gameGenres;
            GameLanguages = gameLanguages;
            GamePublishers = gamePublishers;
            GameSystems = gameSystems;
            GameTags = gameTags;
            Genres = genres;
            Images = images;
            Languages = languages;
            Systems = systems;
            Publishers = publishers;
            Tags = tags;
            Videos = videos;
        }

        public IRepository<Developer> Developers { get; }
        public IRepository<Game> Games { get; }
        public IRepository<GameDeveloper> GameDevelopers { get; }
        public IRepository<GameGenre> GameGenres { get; }
        public IRepository<GameLanguage> GameLanguages { get; }
        public IRepository<GamePublisher> GamePublishers { get; }
        public IRepository<GameSystem> GameSystems { get; }
        public IRepository<GameTag> GameTags { get; }
        public IRepository<Genre> Genres { get; }
        public IRepository<Image> Images { get; }
        public IRepository<Language> Languages { get; }
        public IRepository<OS> Systems { get; }
        public IRepository<Publisher> Publishers { get; }
        public IRepository<Tag> Tags { get; }
        public IRepository<Video> Videos { get; }

        public async Task<OperationInfo> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return new OperationInfo
                {
                    Message = $"Failed to insert entity to database.",
                    Exception = ex
                };
            }
            catch (Exception ex)
            {
                return new OperationInfo
                {
                    Message = $"Failed to save changes to database.",
                    Exception = ex
                };
            }

            return new OperationInfo { Message = $"Successfully saved changes to database." };
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
