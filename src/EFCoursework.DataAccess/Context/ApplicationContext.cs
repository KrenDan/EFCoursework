using EFCoursework.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<OS> Systems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Id).ValueGeneratedNever();

            modelBuilder.Entity<Game>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.Description).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.SteamUrl).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.ClientIconUrl).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.LogoUrl).IsUnique();
            modelBuilder.Entity<Language>().HasIndex(l => l.Name).IsUnique();
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<OS>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<Developer>().HasIndex(d => d.Name).IsUnique();
            modelBuilder.Entity<Developer>().HasIndex(d => d.LogoUrl).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.LogoUrl).IsUnique();
            modelBuilder.Entity<OS>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<OS>().HasIndex(o => o.Icon).IsUnique();
            modelBuilder.Entity<Genre>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<Image>().HasIndex(i => i.Url).IsUnique();
            modelBuilder.Entity<Video>().HasIndex(i => i.Url).IsUnique();

            modelBuilder.Entity<GameDeveloper>()
                .HasKey(g => new { g.GameId, g.DeveloperId });
            modelBuilder.Entity<GameDeveloper>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Developers);
            modelBuilder.Entity<GameDeveloper>()
                .HasOne(g => g.Developer)
                .WithMany(g => g.GameDevelopers);

            modelBuilder.Entity<GameGenre>()
                .HasKey(g => new { g.GameId, g.GenreId });
            modelBuilder.Entity<GameGenre>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Genres);
            modelBuilder.Entity<GameGenre>()
                .HasOne(g => g.Genre)
                .WithMany(g => g.GameGenres);

            modelBuilder.Entity<GameLanguage>()
                .HasKey(g => new { g.GameId, g.LanguageId });
            modelBuilder.Entity<GameLanguage>()
                .HasOne(g => g.Game)
                .WithMany(g => g.SupportedLanguages);
            modelBuilder.Entity<GameLanguage>()
                .HasOne(g => g.Language)
                .WithMany(g => g.GameLanguages);

            modelBuilder.Entity<GamePublisher>()
                .HasKey(g => new { g.GameId, g.PublisherId });
            modelBuilder.Entity<GamePublisher>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Publishers);
            modelBuilder.Entity<GamePublisher>()
                .HasOne(g => g.Publisher)
                .WithMany(g => g.GamePublishers);

            modelBuilder.Entity<GameSystem>()
                .HasKey(g => new { g.GameId, g.OSId });
            modelBuilder.Entity<GameSystem>()
                .HasOne(g => g.Game)
                .WithMany(g => g.SupportedSystems);
            modelBuilder.Entity<GameSystem>()
                .HasOne(g => g.OS)
                .WithMany(g => g.GameSystems);

            modelBuilder.Entity<GameTag>()
                .HasKey(g => new { g.GameId, g.TagId });
            modelBuilder.Entity<GameTag>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Tags);
            modelBuilder.Entity<GameTag>()
                .HasOne(g => g.Tag)
                .WithMany(g => g.GameTags);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Screenshots)
                .WithOne(s => s.Game);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Videos)
                .WithOne(v => v.Game);
        }
    }
}
