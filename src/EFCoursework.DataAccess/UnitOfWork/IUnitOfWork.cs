using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Developer> Developers { get; }
        IRepository<Game> Games { get; }
        IRepository<GameDeveloper> GameDevelopers { get; }
        IRepository<GameGenre> GameGenres { get; }
        IRepository<GameLanguage> GameLanguages { get; }
        IRepository<GamePublisher> GamePublishers { get; }
        IRepository<GameSystem> GameSystems { get; }
        IRepository<GameTag> GameTags { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Image> Images { get; }
        IRepository<Language> Languages { get; }
        IRepository<OS> Systems { get; }
        IRepository<Publisher> Publishers { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Video> Videos { get; }

        Task SaveChangesAsync();
    }
}
