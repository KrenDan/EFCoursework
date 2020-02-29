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

        public override async Task InsertAsync(params Game[] games)
        {
            await _dbSet.AddRangeAsync(games).ConfigureAwait(false);

            foreach (var game in games)
            {
                foreach (var item in game.Genres)
                {
                    var src = await _context.Set<Genre>().FirstOrDefaultAsync(d => d.Name == item.Genre.Name);

                    if (src != null)
                    {
                        item.Genre = src;
                        item.GenreId = src.Id;
                        _context.Entry(src).State = EntityState.Detached;
                    }
                }
                foreach (var item in game.Tags)
                {
                    var src = await _context.Set<Tag>().FirstOrDefaultAsync(d => d.Name == item.Tag.Name);

                    if (src != null)
                    {
                        item.Tag = src;
                        item.TagId = src.Id;
                        _context.Entry(src).State = EntityState.Detached;
                    }
                }
                foreach (var item in game.Developers)
                {
                    var src = await _context.Set<Developer>().FirstOrDefaultAsync(d => d.Name == item.Developer.Name);

                    if (src != null)
                    {
                        item.Developer = src;
                        item.DeveloperId = src.Id;
                        _context.Entry(src).State = EntityState.Detached;
                    }
                }
                foreach (var item in game.SupportedLanguages)
                {
                    var src = await _context.Set<Language>().FirstOrDefaultAsync(d => d.Name == item.Language.Name);

                    if (src != null)
                    {
                        item.Language = src;
                        item.LanguageId = src.Id;
                        _context.Entry(src).State = EntityState.Detached;
                    }
                }
                foreach (var item in game.SupportedSystems)
                {
                    var src = await _context.Set<OS>().FirstOrDefaultAsync(d => d.Name == item.OS.Name);

                    if (src != null)
                    {
                        item.OS = src;
                        item.OSId = src.Id;
                        _context.Entry(src).State = EntityState.Detached;
                    }
                }
            }
        }
    }
}
