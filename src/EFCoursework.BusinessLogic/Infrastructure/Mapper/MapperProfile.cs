using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoursework.BusinessLogic.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, GameDTO>()
                .ForMember(g => g.InterfaceSupportedLanguages, o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.InterfaceSupported).Select(
                    l => new LanguageDTO { Id = l.LanguageId, Name = l.Language.Name }).ToList()))
                .ForMember(g => g.FullAudioSupportedLanguages, o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.FullAudioSupported).Select(
                    l => new LanguageDTO { Id = l.LanguageId, Name = l.Language.Name }).ToList()))
                .ForMember(g => g.SubtitlesSupportedLanguages, o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.SubtitlesSupported).Select(
                    l => new LanguageDTO { Id = l.LanguageId, Name = l.Language.Name }).ToList()));
        }
    }
}
