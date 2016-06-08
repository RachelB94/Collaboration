namespace Collaboration3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg81 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LoginCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LoginCount");
        }
    }
}
