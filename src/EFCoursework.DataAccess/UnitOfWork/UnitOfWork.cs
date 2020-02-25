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

        private GenericRepository<Game> _games;

        public IRepository<Game> Games
        {
            get
            {
                if (_games == null)
                    _games = new GenericRepository<Game>(_context);
                return _games;
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
