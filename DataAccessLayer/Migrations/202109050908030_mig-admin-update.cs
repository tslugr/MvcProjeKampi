namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migadminupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 1),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "AdminName", c => c.String());
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "RoleId", c => c.Int());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Byte(nullable: false));
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "RoleId");
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Admins", "Salt");
            DropColumn("dbo.Admins", "AdminRole");
            DropColumn("dbo.Admins", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AddColumn("dbo.Admins", "Salt", c => c.String());
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 1000));
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 1000));
            DropColumn("dbo.Admins", "RoleId");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminStatus");
            DropColumn("dbo.Admins", "AdminName");
            DropTable("dbo.Roles");
        }
    }
}
