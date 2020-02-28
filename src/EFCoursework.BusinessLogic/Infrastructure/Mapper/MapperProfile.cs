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
            #region Model -> DTO mapping
            CreateMap<OS, OSDTO>().ForMember(dest => dest.Games, 
                opt => opt.MapFrom(src => src.GameSystems.Select(s => s.Game)));

            CreateMap<Developer, DeveloperDTO>().ForMember(dest => dest.Games,
                opt => opt.MapFrom(src => src.GameDevelopers.Select(s => s.Game)));

            CreateMap<Publisher, PublisherDTO>().ForMember(dest => dest.Games,
                opt => opt.MapFrom(src => src.GamePublishers.Select(s => s.Game)));

            CreateMap<Genre, GenreDTO>().ForMember(dest => dest.Games,
                opt => opt.MapFrom(src => src.GameGenres.Select(s => s.Game)));

            CreateMap<Tag, TagDTO>().ForMember(dest => dest.Games,
                opt => opt.MapFrom(src => src.GameTags.Select(s => s.Game)));

            CreateMap<Language, LanguageDTO>().ForMember(dest => dest.Games,
                opt => opt.MapFrom(src => src.GameLanguages.Select(s => s.Game)));

            CreateMap<Image, ImageDTO>();
            CreateMap<Video, VideoDTO>();

            CreateMap<Game, GameDTO>()
                .ForMember(g => g.InterfaceSupportedLanguages, 
                o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.InterfaceSupported).Select(l => l)))
                .ForMember(g => g.FullAudioSupportedLanguages, 
                o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.FullAudioSupported).Select(l => l)))
                .ForMember(g => g.SubtitlesSupportedLanguages, 
                o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.SubtitlesSupported).Select(l => l)));
            #endregion

            #region DTO -> Model mapping
            CreateMap<GameDTO, Game>()
                .ForMember(dest => dest.SupportedSystems, opt => opt.MapFrom(src => src.SupportedSystems))
                .ForMember(dest => dest.Developers, opt => opt.MapFrom(src => src.Developers))
                .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => src.Publishers))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.SupportedLanguages, opt => opt.MapFrom(
                    src => src.FullAudioSupportedLanguages.Concat(src.InterfaceSupportedLanguages).Concat(src.SubtitlesSupportedLanguages)))
                .AfterMap((src, dest) => 
                {
                    foreach (var item in dest.SupportedSystems)
                    {
                        item.Game = dest;
                        item.GameId = dest.Id;
                    }
                    foreach (var item in dest.Developers)
                    {
                        item.Game = dest;
                        item.GameId = dest.Id;
                    }
                    foreach (var item in dest.Publishers)
                    {
                        item.Game = dest;
                        item.GameId = dest.Id;
                    }
                    foreach (var item in dest.Genres)
                    {
                        item.Game = dest;
                        item.GameId = dest.Id;
                    }
                    foreach (var item in dest.Tags)
                    {
                        item.Game = dest;
                        item.GameId = dest.Id;
                    }
                    foreach (var item in dest.SupportedLanguages)
                    {
                        item.Game = dest;
                        item.GameId = dest.Id;
                    }
                });

            CreateMap<OSDTO, GameSystem>()
                .ForMember(dest => dest.OS, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.OSId, opt => opt.MapFrom(src => src.Id));
            CreateMap<OSDTO, OS>();

            CreateMap<DeveloperDTO, GameDeveloper>()
                .ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.DeveloperId, opt => opt.MapFrom(src => src.Id));
            CreateMap<DeveloperDTO, Developer>();

            CreateMap<PublisherDTO, GamePublisher>()
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.Id));
            CreateMap<PublisherDTO, Publisher>();

            CreateMap<GenreDTO, GameGenre>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id));
            CreateMap<GenreDTO, Genre>();

            CreateMap<TagDTO, GameTag>()
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Id));
            CreateMap<TagDTO, Tag>();

            CreateMap<LanguageDTO, GameLanguage>()
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Id));
            CreateMap<LanguageDTO, Language>();

            CreateMap<ImageDTO, Image>();
            CreateMap<VideoDTO, Video>();
            #endregion
        }
    }
}
