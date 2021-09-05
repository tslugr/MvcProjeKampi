namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editheading : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "Heading_HeadingID", "dbo.Headings");
            DropIndex("dbo.Headings", new[] { "Heading_HeadingID" });
            DropColumn("dbo.Headings", "Heading_HeadingID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "Heading_HeadingID", c => c.Int());
            CreateIndex("dbo.Headings", "Heading_HeadingID");
            AddForeignKey("dbo.Headings", "Heading_HeadingID", "dbo.Headings", "HeadingID");
        }
    }
}
