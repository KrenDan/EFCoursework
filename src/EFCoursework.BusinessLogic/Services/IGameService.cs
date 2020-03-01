using EFCoursework.BusinessLogic.DTO;
using EFCoursework.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.BusinessLogic.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetGamesAsync(Expression<Func<Game, bool>> predicate);
        Task<IEnumerable<GameDTO>> GetAllGamesAsync();
        Task InsertGamesAsync(IEnumerable<GameDTO> games);
        Task DeleteGamesAsync(Expression<Func<Game, bool>> predicate);
    }
}
