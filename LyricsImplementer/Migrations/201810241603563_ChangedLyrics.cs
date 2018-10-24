namespace LyricsImplementer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLyrics : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LyricsLanguage", "LyricsId", "dbo.Lyrics");
            DropForeignKey("dbo.LyricsLanguage", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.LyricsSong", "LyricsId", "dbo.Lyrics");
            DropForeignKey("dbo.LyricsSong", "SongId", "dbo.Songs");
            DropIndex("dbo.LyricsLanguage", new[] { "LyricsId" });
            DropIndex("dbo.LyricsLanguage", new[] { "LanguageId" });
            DropIndex("dbo.LyricsSong", new[] { "LyricsId" });
            DropIndex("dbo.LyricsSong", new[] { "SongId" });
            AddColumn("dbo.Lyrics", "SongId", c => c.Int());
            AddColumn("dbo.Lyrics", "LanguageId", c => c.Int());
            AlterColumn("dbo.Users", "Login", c => c.String());
            AlterColumn("dbo.Users", "Nickname", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            CreateIndex("dbo.Lyrics", "SongId");
            CreateIndex("dbo.Lyrics", "LanguageId");
            AddForeignKey("dbo.Lyrics", "LanguageId", "dbo.Languages", "LanguageId");
            AddForeignKey("dbo.Lyrics", "SongId", "dbo.Songs", "SongId");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.LyricsSong",
                c => new
                {
                    LyricsId = c.Int(nullable: false),
                    SongId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.LyricsId, t.SongId });

            CreateTable(
                "dbo.LyricsLanguage",
                c => new
                {
                    LyricsId = c.Int(nullable: false),
                    LanguageId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.LyricsId, t.LanguageId });

            DropForeignKey("dbo.Lyrics", "SongId", "dbo.Songs");
            DropForeignKey("dbo.Lyrics", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Lyrics", new[] { "LanguageId" });
            DropIndex("dbo.Lyrics", new[] { "SongId" });
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Nickname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false));
            DropColumn("dbo.Lyrics", "LanguageId");
            DropColumn("dbo.Lyrics", "SongId");
            CreateIndex("dbo.LyricsSong", "SongId");
            CreateIndex("dbo.LyricsSong", "LyricsId");
            CreateIndex("dbo.LyricsLanguage", "LanguageId");
            CreateIndex("dbo.LyricsLanguage", "LyricsId");
            AddForeignKey("dbo.LyricsSong", "SongId", "dbo.Songs", "SongId", cascadeDelete: true);
            AddForeignKey("dbo.LyricsSong", "LyricsId", "dbo.Lyrics", "LyricsId", cascadeDelete: true);
            AddForeignKey("dbo.LyricsLanguage", "LanguageId", "dbo.Languages", "LanguageId", cascadeDelete: true);
            AddForeignKey("dbo.LyricsLanguage", "LyricsId", "dbo.Lyrics", "LyricsId", cascadeDelete: true);
        }
    }
}
