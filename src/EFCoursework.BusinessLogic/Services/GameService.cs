using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GameDTO>> GetAllGamesAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>()).CreateMapper();
            var games = await _unitOfWork.Games.GetAll().ToListAsync();
            return mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(games);
        }
    }
}
