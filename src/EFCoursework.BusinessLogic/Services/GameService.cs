using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDTO>> GetAllGamesAsync()
        {
            var games = await _unitOfWork.Games.GetAllAsync();
            return _mapper.Map<IEnumerable<GameDTO>>(games);
        }

        public async Task<IEnumerable<GameDTO>> GetGamesAsync(Expression<Func<Game, bool>> predicate)
        {
            var games = await _unitOfWork.Games.GetAsync(predicate);
            return _mapper.Map<IEnumerable<GameDTO>>(games);
        }

        public async Task InsertGamesAsync(IEnumerable<GameDTO> games)
        {
            foreach (var game in games)
            {
                var gameModel = _mapper.Map<Game>(game);
                await _unitOfWork.Games.InsertAsync(gameModel);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteGamesAsync(Expression<Func<Game, bool>> predicate)
        {
            await _unitOfWork.Games.DeleteAsync(predicate);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
