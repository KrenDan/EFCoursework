using AutoMapper;
using EFCoursework.BusinessLogic.DTO;
using EFCoursework.DataAccess.UnitOfWork;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.BusinessLogic.Services
{
    public class SteamParseService : IParseService<IEnumerable<GameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SteamParseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDTO>> ParseAsync()
        {
            var result = new List<GameDTO>();

            string infoUrl = "https://steamdb.info/app/1085660/info/";
            string pricesUrl = "https://steamdb.info/app/1085660/";
            string screenshotsUrl = "https://steamdb.info/app/1085660/screenshots/";

            var web = new HtmlWeb();
            
            var infoDoc = await web.LoadFromWebAsync(infoUrl);
            var pricesDoc = await web.LoadFromWebAsync(pricesUrl);
            var screenshotsDoc = await web.LoadFromWebAsync(screenshotsUrl);

            string steamUrl = infoDoc.DocumentNode.SelectSingleNode(@"/html/body/div[1]/div[1]/div[2]/div/div/div[2]/div[1]/nav/a[1]").GetAttributeValue("href", "");

            var steamDoc = await web.LoadFromWebAsync(steamUrl);

            var game = new GameDTO
            {
                Id = GetAppId(infoDoc),
                Title = GetName(infoDoc),
                Description = GetDescription(infoDoc),
                Price = GetPrice(pricesDoc),
                Discount = GetDiscount(infoDoc),
                ReviewCount = GetReviewCount(infoDoc),
                ReviewScore = GetReviewScore(infoDoc),
                ReviewPercentage = GetReviewPercentage(infoDoc),
                Developers = GetDevelopers(infoDoc),
                Publishers = GetPublishers(infoDoc),
                SupportedSystems = GetSystems(infoDoc),
                Genres = GetGenres(infoDoc),
                Tags = GetTags(infoDoc),
                Screenshots = GetScreenshots(infoDoc, screenshotsDoc),
                Videos = GetVideos(infoDoc),
                ReleaseDate = GetReleaseDate(infoDoc),
                ClientIconUrl = GetClientIconUrl(infoDoc),
                LogoUrl = GetLogoUrl(infoDoc),
                SteamUrl = GetSteamUrl(infoDoc),
                //IsReleased = GetIsReleased(infoDoc),
                //InterfaceSupportedLanguages = GetInterfaceSupportedLanguages(infoDoc),
                //FullAudioSupportedLanguages = GetFullAudioSupportedLanguages(infoDoc),
                //SubtitlesSupportedLanguages = GetSubtitlesSupportedLanguages(infoDoc)
            };

            result.Add(game);

            return result;
        }

        private int GetAppId(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[.='App ID']/../td[2]");

            if (node == null)
                return -1;

            string text = node.InnerText;
            int.TryParse(text, out int id);
            return id;
        }
        private string GetName(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[@itemprop='name']");

            if (node == null)
                return "";

            return node.InnerText;
        }
        private string GetDescription(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[@itemprop='description']");

            if (node == null)
                return "";

            return node.InnerText;
        }
        private decimal GetPrice(HtmlDocument pricesDoc)
        {
            var node = pricesDoc.DocumentNode.SelectSingleNode(@"//*[@data-cc='ua']/../td[2]");

            if (node == null)
                return -1;

            string text = node.InnerText;
            text = text.Substring(0, text.Length - 1);
            decimal.TryParse(text, out decimal price);
            return price;
        }
        private int GetDiscount(HtmlDocument doc)
        {
            return 0;
        }
        private int GetReviewCount(HtmlDocument doc)
        {
            var node1 = doc.DocumentNode.SelectSingleNode(@"//*[@class='header-thing-good']");
            var node2 = doc.DocumentNode.SelectSingleNode(@"//*[@class='header-thing-poor']");

            if (node1 == null || node2 == null)
                return -1;

            string text1 = node1.InnerText;
            int.TryParse(text1, out int scoreGood);
            string text2 = node1.InnerText;
            int.TryParse(text2, out int scoreBad);
            
            return scoreGood + scoreBad;
        }
        private int GetReviewScore(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//td[.='review_score']/../td[2]");

            if (node == null)
                return -1;

            string text = node.InnerText;
            int.TryParse(text, out int score);
            return score;
        }
        private float GetReviewPercentage(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[@class='header-thing-number header-thing-good']");

            if (node == null)
                return -1;

            string text = node.InnerText;
            text = text.Replace("😋 ", "");
            text = text.Replace("%", "");
            int.TryParse(text, out int percentage);
            return percentage;
        }
        private List<DeveloperDTO> GetDevelopers(HtmlDocument doc)
        {
            var developers = new List<DeveloperDTO>();
            var node = doc.DocumentNode.SelectSingleNode(@"//*[@itemprop='author']");

            if (node == null)
                return developers;

            string name = node.InnerText;
            developers.Add(new DeveloperDTO
            {
                Name = name
            });

            return developers; 
        }
        private List<PublisherDTO> GetPublishers(HtmlDocument doc)
        {
            var publishers = new List<PublisherDTO>();
            var node = doc.DocumentNode.SelectSingleNode(@"//*[@itemprop='publisher']");

            if (node == null)
                return publishers;

            string name = node.InnerText;
            publishers.Add(new PublisherDTO
            {
                Name = name
            });

            return publishers;
        }
        private List<OSDTO> GetSystems(HtmlDocument doc)
        {
            var systems = new List<OSDTO>();

            var nodes = doc.DocumentNode.SelectNodes(@"//*[.='Supported Systems']/../td[2]/svg");

            var node = doc.DocumentNode.SelectSingleNode(@"//*[@itemprop='operatingSystem']");

            if (nodes == null || node == null)
                return systems;

            string namesStr = node.GetAttributeValue("content", "");
            string[] names = namesStr.Split(',', StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < names.Length; i++)
            {
                string icon = nodes[i].FirstChild.GetAttributeValue("d", "");
                systems.Add(new OSDTO
                {
                    Name = names[i],
                    Icon = icon
                });
            }

            return systems;
        }
        private List<GenreDTO> GetGenres(HtmlDocument doc)
        {
            var genres = new List<GenreDTO>();

            var genreNodes = doc.DocumentNode.SelectNodes(@"//*[.='Store Genres']/../td[2]/text()");

            if (genreNodes == null)
                return genres;

            for (int i = 0; i < genreNodes.Count; i++)
            {
                string name = genreNodes[i].InnerText;
                name = name.Replace(" ", "");
                name = name.Replace("(", "");
                name = name.Replace(")", "");
                name = name.Replace(",", "");

                genres.Add(new GenreDTO
                {
                    Name = name
                });
            }

            return genres;
        }
        private List<TagDTO> GetTags(HtmlDocument doc)
        {
            var tags = new List<TagDTO>();

            var tagNodes = doc.DocumentNode.SelectNodes(@"//*[.='Store Genres']/../td[2]/text()");

            if (tagNodes == null)
                return tags;

            for (int i = 0; i < tagNodes.Count; i++)
            {
                string name = tagNodes[i].InnerText;
                name = name.Replace(" ", "");
                name = name.Replace("(", "");
                name = name.Replace(")", "");
                name = name.Replace(",", "");

                tags.Add(new TagDTO
                {
                    Name = name
                });
            }

            return tags;
        }
        private List<ImageDTO> GetScreenshots(HtmlDocument doc, HtmlDocument screenshotsDoc)
        {
            var images = new List<ImageDTO>();

            var nodes = screenshotsDoc.DocumentNode.SelectNodes("//*[@id='screenshots']/a");

            if (nodes == null)
                return images;

            for (int i = 0; i < nodes.Count; i++)
            {
                images.Add(new ImageDTO
                {
                    Url = nodes[i].GetAttributeValue("href", "")
                });
            }

            return images;
        }
        private List<VideoDTO> GetVideos(HtmlDocument doc)
        {
            var videos = new List<VideoDTO>();

            var node = doc.DocumentNode.SelectSingleNode("//*[.='Microtrailer']/../td[2]");

            if (node == null)
                return videos;

            videos.Add(new VideoDTO 
            { 
                Url = node.InnerText
            });

            return videos;
        }
        private DateTime GetReleaseDate(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[.='Store Release Date']/../td[2]");

            if (node == null)
                return new DateTime();

            string text = node.InnerText;
            DateTime.TryParseExact(text, "d MMMM yyyy '–' HH':'mm':'ss 'UTC' ", CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out DateTime date);
            return date;
        }
        private string GetClientIconUrl(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[.='clienticon']/../td[2]/a");

            if (node == null)
                return "";

            return node.GetAttributeValue("href", "");
        }
        private string GetLogoUrl(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//*[.='logo']/../td[2]/a");

            if (node == null)
                return "";

            return node.GetAttributeValue("href", "");
        }
        private string GetSteamUrl(HtmlDocument doc)
        {
            var node = doc.DocumentNode.SelectSingleNode(@"//img[@alt='Steam']/..");

            if (node == null)
                return "";

            return node.GetAttributeValue("href", "");
        }
    }
}
