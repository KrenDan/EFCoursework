using EFCoursework.DataAccess.Context;
using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private GenericRepository<Developer> _developers;
        private GenericRepository<Game> _games;
        private GenericRepository<GameDeveloper> _gameDevelopers;
        private GenericRepository<GameGenre> _gameGenres;
        private GenericRepository<GameLanguage> _gameLanguages;
        private GenericRepository<GamePublisher> _gamePublishers;
        private GenericRepository<GameSystem> _gameSystems;
        private GenericRepository<GameTag> _gameTags;
        private GenericRepository<Genre> _genres;
        private GenericRepository<Image> _images;
        private GenericRepository<Language> _languages;
        private GenericRepository<OS> _systems;
        private GenericRepository<Publisher> _publishers;
        private GenericRepository<Tag> _tags;
        private GenericRepository<Video> _videos;

        public IRepository<Developer> Developers
        {
            get
            {
                if (_developers == null)
                    _developers = new GenericRepository<Developer>(_context);
                return _developers;
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                if (_games == null)
                    _games = new GenericRepository<Game>(_context);
                return _games;
            }
        }

        public IRepository<GameDeveloper> GameDevelopers
        {
            get
            {
                if (_gameDevelopers == null)
                    _gameDevelopers = new GenericRepository<GameDeveloper>(_context);
                return _gameDevelopers;
            }
        }

        public IRepository<GameGenre> GameGenres
        {
            get
            {
                if (_gameGenres == null)
                    _gameGenres = new GenericRepository<GameGenre>(_context);
                return _gameGenres;
            }
        }

        public IRepository<GameLanguage> GameLanguages
        {
            get
            {
                if (_gameLanguages == null)
                    _gameLanguages = new GenericRepository<GameLanguage>(_context);
                return _gameLanguages;
            }
        }

        public IRepository<GamePublisher> GamePublishers
        {
            get
            {
                if (_gamePublishers == null)
                    _gamePublishers = new GenericRepository<GamePublisher>(_context);
                return _gamePublishers;
            }
        }

        public IRepository<GameSystem> GameSystems
        {
            get
            {
                if (_gameSystems == null)
                    _gameSystems = new GenericRepository<GameSystem>(_context);
                return _gameSystems;
            }
        }

        public IRepository<GameTag> GameTags
        {
            get
            {
                if (_gameTags == null)
                    _gameTags = new GenericRepository<GameTag>(_context);
                return _gameTags;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (_genres == null)
                    _genres = new GenericRepository<Genre>(_context);
                return _genres;
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                if (_images == null)
                    _images = new GenericRepository<Image>(_context);
                return _images;
            }
        }

        public IRepository<Language> Languages
        {
            get
            {
                if (_languages == null)
                    _languages = new GenericRepository<Language>(_context);
                return _languages;
            }
        }

        public IRepository<OS> Systems
        {
            get
            {
                if (_systems == null)
                    _systems = new GenericRepository<OS>(_context);
                return _systems;
            }
        }

        public IRepository<Publisher> Publishers
        {
            get
            {
                if (_publishers == null)
                    _publishers = new GenericRepository<Publisher>(_context);
                return _publishers;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (_tags == null)
                    _tags = new GenericRepository<Tag>(_context);
                return _tags;
            }
        }

        public IRepository<Video> Videos
        {
            get
            {
                if (_videos == null)
                    _videos = new GenericRepository<Video>(_context);
                return _videos;
            }
        }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
