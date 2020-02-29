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
            CreateMap<Game, GameDTO>()
                .ForMember(dest => dest.SupportedSystems, opt => opt.MapFrom(src => src.SupportedSystems))
                .ForMember(dest => dest.Developers, opt => opt.MapFrom(src => src.Developers))
                .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => src.Publishers))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(g => g.InterfaceSupportedLanguages,
                o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.InterfaceSupported).Select(l => l)))
                .ForMember(g => g.FullAudioSupportedLanguages,
                o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.FullAudioSupported).Select(l => l)))
                .ForMember(g => g.SubtitlesSupportedLanguages,
                o => o.MapFrom(g => g.SupportedLanguages.Where(l => l.SubtitlesSupported).Select(l => l)))
                .AfterMap((src, dest) =>
                {
                    foreach (var item in dest.SupportedSystems)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.Developers)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.Publishers)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.Genres)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.Tags)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.FullAudioSupportedLanguages)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.InterfaceSupportedLanguages)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.SubtitlesSupportedLanguages)
                    {
                        if (item.Games == null)
                            item.Games = new List<GameDTO>();
                        item.Games.Add(dest);
                    }
                    foreach (var item in dest.Screenshots)
                    {
                        item.Game = dest;
                    }
                    foreach (var item in dest.Videos)
                    {
                        item.Game = dest;
                    }
                });

            CreateMap<GameSystem, OSDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OSId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OS.Name))
                .ForMember(dest => dest.Games, opt => opt.Ignore());

            CreateMap<GameDeveloper, DeveloperDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DeveloperId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Developer.Name))
                .ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.Developer.LogoUrl))
                .ForMember(dest => dest.Games, opt => opt.Ignore());

            CreateMap<GamePublisher, PublisherDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublisherId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.Publisher.LogoUrl))
                .ForMember(dest => dest.Games, opt => opt.Ignore());

            CreateMap<GameGenre, GenreDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GenreId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Games, opt => opt.Ignore());

            CreateMap<GameTag, TagDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Tag.Name))
                .ForMember(dest => dest.Games, opt => opt.Ignore());

            CreateMap<GameLanguage, LanguageDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Language.Name))
                .ForMember(dest => dest.Games, opt => opt.Ignore());

            CreateMap<Image, ImageDTO>();
            CreateMap<Video, VideoDTO>();
            #endregion

            #region DTO -> Model mapping
            CreateMap<GameDTO, Game>()
                .ForMember(dest => dest.SupportedSystems, opt => opt.MapFrom(src => src.SupportedSystems))
                .ForMember(dest => dest.Developers, opt => opt.MapFrom(src => src.Developers))
                .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => src.Publishers))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.SupportedLanguages, opt => opt.MapFrom(
                    src => src.FullAudioSupportedLanguages.Concat(src.InterfaceSupportedLanguages).Concat(src.SubtitlesSupportedLanguages)
                    .Distinct(new LanguageDTOEqualityComparer())))
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
                        item.FullAudioSupported = src.FullAudioSupportedLanguages.FirstOrDefault(l => l.Name == item.Language.Name) != null;
                        item.InterfaceSupported = src.InterfaceSupportedLanguages.FirstOrDefault(l => l.Name == item.Language.Name) != null;
                        item.SubtitlesSupported = src.SubtitlesSupportedLanguages.FirstOrDefault(l => l.Name == item.Language.Name) != null;
                    }
                    foreach (var item in dest.Screenshots)
                    {
                        item.Game = dest;
                    }
                    foreach (var item in dest.Videos)
                    {
                        item.Game = dest;
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
