namespace LyricsImplementer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Length = c.String(),
                        Notation = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Email = c.String(),
                        Birth = c.DateTime(nullable: false),
                        Origin = c.String(),
                        YearsActive = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Notation = c.String(),
                        AlbumId = c.Int(),
                        UserId = c.Int(),
                        Album_AlbumId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Lyrics",
                c => new
                    {
                        LyricsId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.LyricsId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        SongId = c.Int(nullable: false),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        PasswordConfirm = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ArtistAlbum",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        AlbumId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.AlbumId })
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.GenreSong",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GenreId, t.SongId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.LyricsLanguage",
                c => new
                    {
                        LyricsId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LyricsId, t.LanguageId })
                .ForeignKey("dbo.Lyrics", t => t.LyricsId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LyricsId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.LyricsSong",
                c => new
                    {
                        LyricsId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LyricsId, t.SongId })
                .ForeignKey("dbo.Lyrics", t => t.LyricsId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.LyricsId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.ArtistSong",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.SongId })
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistSong", "SongId", "dbo.Songs");
            DropForeignKey("dbo.ArtistSong", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "UserId", "dbo.Users");
            DropForeignKey("dbo.LyricsSong", "SongId", "dbo.Songs");
            DropForeignKey("dbo.LyricsSong", "LyricsId", "dbo.Lyrics");
            DropForeignKey("dbo.LyricsLanguage", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.LyricsLanguage", "LyricsId", "dbo.Lyrics");
            DropForeignKey("dbo.GenreSong", "SongId", "dbo.Songs");
            DropForeignKey("dbo.GenreSong", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Songs", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbum", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbum", "ArtistId", "dbo.Artists");
            DropIndex("dbo.ArtistSong", new[] { "SongId" });
            DropIndex("dbo.ArtistSong", new[] { "ArtistId" });
            DropIndex("dbo.LyricsSong", new[] { "SongId" });
            DropIndex("dbo.LyricsSong", new[] { "LyricsId" });
            DropIndex("dbo.LyricsLanguage", new[] { "LanguageId" });
            DropIndex("dbo.LyricsLanguage", new[] { "LyricsId" });
            DropIndex("dbo.GenreSong", new[] { "SongId" });
            DropIndex("dbo.GenreSong", new[] { "GenreId" });
            DropIndex("dbo.ArtistAlbum", new[] { "AlbumId" });
            DropIndex("dbo.ArtistAlbum", new[] { "ArtistId" });
            DropIndex("dbo.Songs", new[] { "Album_AlbumId" });
            DropIndex("dbo.Songs", new[] { "UserId" });
            DropTable("dbo.ArtistSong");
            DropTable("dbo.LyricsSong");
            DropTable("dbo.LyricsLanguage");
            DropTable("dbo.GenreSong");
            DropTable("dbo.ArtistAlbum");
            DropTable("dbo.Users");
            DropTable("dbo.Languages");
            DropTable("dbo.Lyrics");
            DropTable("dbo.Genres");
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
