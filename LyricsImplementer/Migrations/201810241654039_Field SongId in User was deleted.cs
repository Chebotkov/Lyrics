namespace LyricsImplementer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldSongIdinUserwasdeleted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Login", c => c.String());
            AlterColumn("dbo.Users", "Nickname", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "SongId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SongId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Nickname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false));
        }
    }
}
