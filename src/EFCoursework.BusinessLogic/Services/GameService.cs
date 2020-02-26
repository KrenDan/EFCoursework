using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _unitOfWork.Games.GetAll()
                .Select(g => new GameDTO
                {
                    Id = g.Id,
                    SupportedSystems = g.SupportedSystems.Select(
                        s => new OSDTO { Id = s.OSId, Name = s.OS.Name, IconUrl = s.OS.IconUrl }).ToList(),
                    Developers = g.Developers.Select(
                        d => new DeveloperDTO { Id = d.DeveloperId, Name = d.Developer.Name, LogoUrl = d.Developer.LogoUrl }).ToList(),
                    Publishers = g.Publishers.Select(
                        p => new PublisherDTO { Id = p.PublisherId, Name = p.Publisher.Name, LogoUrl = p.Publisher.LogoUrl }).ToList(),
                    Genres = g.Genres.Select(
                        g => new GenreDTO { Id = g.GenreId, Name = g.Genre.Name }).ToList(),
                    Tags = g.Tags.Select(
                        t => new TagDTO { Id = t.TagId, Name = t.Tag.Name }).ToList(),
                    Screenshots = g.Screenshots.Select(
                        s => new ImageDTO { Id = s.Id, Url = s.Url, GameId = g.Id }).ToList(),
                    Videos = g.Videos.Select(
                        v => new VideoDTO { Id = v.Id, Url = v.Url, GameId = g.Id }).ToList(),
                    InterfaceSupportedLanguages = g.SupportedLanguages.Where(l => l.InterfaceSupported).Select(
                        l => new LanguageDTO { Id = l.LanguageId, Name = l.Language.Name }).ToList(),
                    FullAudioSupportedLanguages = g.SupportedLanguages.Where(l => l.FullAudioSupported).Select(
                        l => new LanguageDTO { Id = l.LanguageId, Name = l.Language.Name }).ToList(),
                    SubtitlesSupportedLanguages = g.SupportedLanguages.Where(l => l.SubtitlesSupported).Select(
                        l => new LanguageDTO { Id = l.LanguageId, Name = l.Language.Name }).ToList()
                }).ToListAsync();
        }
    }
}
