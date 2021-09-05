﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migwriteredit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
        }
    }
}