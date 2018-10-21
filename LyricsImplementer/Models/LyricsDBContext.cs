﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class LyricsDBContext : DbContext
    {
        public LyricsDBContext() : base ("LyricsDBContext")
        { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Lyrics> Lyrics { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArtistConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new LyricsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class LyricsConfiguration : EntityTypeConfiguration<Lyrics>
    {
        public LyricsConfiguration()
        {
            HasMany(l => l.Songs)
                .WithMany(s => s.LyricsList)
                .Map(t =>
                {
                    t.MapLeftKey("LyricsId");
                    t.MapRightKey("SongId");
                    t.ToTable("LyricsSong");
                });

            HasMany(l => l.Languages)
                .WithMany(l => l.LyricsList)
                .Map(t =>
                {
                    t.MapLeftKey("LyricsId");
                    t.MapRightKey("LanguageId");
                    t.ToTable("LyricsLanguage");
                });
        }
    }

    public class ArtistConfiguration : EntityTypeConfiguration<Artist>
    {
        public ArtistConfiguration()
        {
            HasMany(a => a.Songs)
                .WithMany(s => s.Artists)
                .Map(t => t.MapLeftKey("ArtistId")
                .MapRightKey("SongId")
                .ToTable("ArtistSong"));

            HasMany(ar => ar.Albums)
                .WithMany(a => a.Artists)
                .Map(t => t.MapLeftKey("ArtistId")
                .MapRightKey("AlbumId")
                .ToTable("ArtistAlbum"));
        }
    }

    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            HasMany(g => g.Songs)
                .WithMany(s => s.Genres)
                .Map(t => t.MapLeftKey("GenreId")
                .MapRightKey("SongId")
                .ToTable("GenreSong"));
        }
    }
}