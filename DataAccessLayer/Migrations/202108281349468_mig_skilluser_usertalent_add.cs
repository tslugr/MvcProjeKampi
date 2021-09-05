namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skilluser_usertalent_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 100),
                        UserDetails = c.String(maxLength: 250),
                        SocialMedia = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserTalents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        TalentTitle = c.String(maxLength: 100),
                        TalentLevel = c.Byte(nullable: false),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.TalentID)
                .ForeignKey("dbo.SkillUsers", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTalents", "UserID", "dbo.SkillUsers");
            DropIndex("dbo.UserTalents", new[] { "UserID" });
            DropTable("dbo.UserTalents");
            DropTable("dbo.SkillUsers");
        }
    }
}
