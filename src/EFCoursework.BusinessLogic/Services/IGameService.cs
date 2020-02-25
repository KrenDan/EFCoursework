using EFCoursework.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.BusinessLogic.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetAllGamesAsync();
    }
}
