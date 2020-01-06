namespace DatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Profile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Profile");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
