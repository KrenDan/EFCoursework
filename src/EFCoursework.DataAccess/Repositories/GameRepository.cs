using EFCoursework.DataAccess.Context;
using EFCoursework.DataAccess.Infrastructure;
using EFCoursework.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {
        public GameRepository(DbContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<Game>> GetAllAsync()
        {
            return await _dbSet
                .Include(g => g.SupportedSystems)
                .Include(g => g.Developers)
                .Include(g => g.Publishers)
                .Include(g => g.Genres)
                .Include(g => g.Tags)
                .Include(g => g.Screenshots)
                .Include(g => g.Videos)
                .Include(g => g.SupportedLanguages)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Game>> GetAsync(Expression<Func<Game, bool>> predicate)
        {
            return await _dbSet
                .Include(g => g.SupportedSystems)
                .Include(g => g.Developers)
                .Include(g => g.Publishers)
                .Include(g => g.Genres)
                .Include(g => g.Tags)
                .Include(g => g.Screenshots)
                .Include(g => g.Videos)
                .Include(g => g.SupportedLanguages)
                .Where(predicate).ToListAsync().ConfigureAwait(false);
        }
    }
}
