namespace Collaboration3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImageByte", c => c.Binary());
            
        }
        
        public override void Down()
        {
            
          
        }
    }
}
