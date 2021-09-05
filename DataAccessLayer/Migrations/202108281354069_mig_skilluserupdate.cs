namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skilluserupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTalents", "SocialMedia", c => c.String());
            DropColumn("dbo.SkillUsers", "SocialMedia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SkillUsers", "SocialMedia", c => c.String(maxLength: 250));
            DropColumn("dbo.UserTalents", "SocialMedia");
        }
    }
}
