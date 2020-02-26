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

        private BaseRepository<Developer> _developers;
        private BaseRepository<Game> _games;
        private BaseRepository<GameDeveloper> _gameDevelopers;
        private BaseRepository<GameGenre> _gameGenres;
        private BaseRepository<GameLanguage> _gameLanguages;
        private BaseRepository<GamePublisher> _gamePublishers;
        private BaseRepository<GameSystem> _gameSystems;
        private BaseRepository<GameTag> _gameTags;
        private BaseRepository<Genre> _genres;
        private BaseRepository<Image> _images;
        private BaseRepository<Language> _languages;
        private BaseRepository<OS> _systems;
        private BaseRepository<Publisher> _publishers;
        private BaseRepository<Tag> _tags;
        private BaseRepository<Video> _videos;

        public IRepository<Developer> Developers
        {
            get
            {
                if (_developers == null)
                    _developers = new BaseRepository<Developer>(_context);
                return _developers;
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                if (_games == null)
                    _games = new BaseRepository<Game>(_context);
                return _games;
            }
        }

        public IRepository<GameDeveloper> GameDevelopers
        {
            get
            {
                if (_gameDevelopers == null)
                    _gameDevelopers = new BaseRepository<GameDeveloper>(_context);
                return _gameDevelopers;
            }
        }

        public IRepository<GameGenre> GameGenres
        {
            get
            {
                if (_gameGenres == null)
                    _gameGenres = new BaseRepository<GameGenre>(_context);
                return _gameGenres;
            }
        }

        public IRepository<GameLanguage> GameLanguages
        {
            get
            {
                if (_gameLanguages == null)
                    _gameLanguages = new BaseRepository<GameLanguage>(_context);
                return _gameLanguages;
            }
        }

        public IRepository<GamePublisher> GamePublishers
        {
            get
            {
                if (_gamePublishers == null)
                    _gamePublishers = new BaseRepository<GamePublisher>(_context);
                return _gamePublishers;
            }
        }

        public IRepository<GameSystem> GameSystems
        {
            get
            {
                if (_gameSystems == null)
                    _gameSystems = new BaseRepository<GameSystem>(_context);
                return _gameSystems;
            }
        }

        public IRepository<GameTag> GameTags
        {
            get
            {
                if (_gameTags == null)
                    _gameTags = new BaseRepository<GameTag>(_context);
                return _gameTags;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (_genres == null)
                    _genres = new BaseRepository<Genre>(_context);
                return _genres;
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                if (_images == null)
                    _images = new BaseRepository<Image>(_context);
                return _images;
            }
        }

        public IRepository<Language> Languages
        {
            get
            {
                if (_languages == null)
                    _languages = new BaseRepository<Language>(_context);
                return _languages;
            }
        }

        public IRepository<OS> Systems
        {
            get
            {
                if (_systems == null)
                    _systems = new BaseRepository<OS>(_context);
                return _systems;
            }
        }

        public IRepository<Publisher> Publishers
        {
            get
            {
                if (_publishers == null)
                    _publishers = new BaseRepository<Publisher>(_context);
                return _publishers;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (_tags == null)
                    _tags = new BaseRepository<Tag>(_context);
                return _tags;
            }
        }

        public IRepository<Video> Videos
        {
            get
            {
                if (_videos == null)
                    _videos = new BaseRepository<Video>(_context);
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
