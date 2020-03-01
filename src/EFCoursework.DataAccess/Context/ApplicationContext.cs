using EFCoursework.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EFCoursework.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();
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

            modelBuilder.Entity<Game>().HasIndex(g => g.Description).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.SteamUrl).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.ClientIconUrl).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(g => g.LogoUrl).IsUnique();
            modelBuilder.Entity<Language>().HasIndex(l => l.Name).IsUnique();
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Developer>().HasIndex(d => d.Name).IsUnique();
            modelBuilder.Entity<Developer>().HasIndex(d => d.LogoUrl).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Publisher>().HasIndex(p => p.LogoUrl).IsUnique();
            modelBuilder.Entity<OS>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<Genre>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<Image>().HasIndex(i => i.Url).IsUnique();
            modelBuilder.Entity<Video>().HasIndex(i => i.Url).IsUnique();

            modelBuilder.Entity<GameDeveloper>()
                .HasKey(g => new { g.GameId, g.DeveloperId });
            modelBuilder.Entity<GameDeveloper>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Developers)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<GameDeveloper>()
                .HasOne(g => g.Developer)
                .WithMany(g => g.GameDevelopers)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<GameGenre>()
                .HasKey(g => new { g.GameId, g.GenreId });
            modelBuilder.Entity<GameGenre>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Genres)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<GameGenre>()
                .HasOne(g => g.Genre)
                .WithMany(g => g.GameGenres)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<GameLanguage>()
                .HasKey(g => new { g.GameId, g.LanguageId });
            modelBuilder.Entity<GameLanguage>()
                .HasOne(g => g.Game)
                .WithMany(g => g.SupportedLanguages)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<GameLanguage>()
                .HasOne(g => g.Language)
                .WithMany(g => g.GameLanguages)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<GamePublisher>()
                .HasKey(g => new { g.GameId, g.PublisherId });
            modelBuilder.Entity<GamePublisher>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Publishers)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<GamePublisher>()
                .HasOne(g => g.Publisher)
                .WithMany(g => g.GamePublishers)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<GameSystem>()
                .HasKey(g => new { g.GameId, g.OSId });
            modelBuilder.Entity<GameSystem>()
                .HasOne(g => g.Game)
                .WithMany(g => g.SupportedSystems)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<GameSystem>()
                .HasOne(g => g.OS)
                .WithMany(g => g.GameSystems)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<GameTag>()
                .HasKey(g => new { g.GameId, g.TagId });
            modelBuilder.Entity<GameTag>()
                .HasOne(g => g.Game)
                .WithMany(g => g.Tags)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<GameTag>()
                .HasOne(g => g.Tag)
                .WithMany(g => g.GameTags)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Game)
                .WithMany(g => g.Screenshots)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Video>()
                .HasOne(i => i.Game)
                .WithMany(g => g.Videos)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EFCoursework.WPF"))
                .AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = config.GetConnectionString("AzureConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
