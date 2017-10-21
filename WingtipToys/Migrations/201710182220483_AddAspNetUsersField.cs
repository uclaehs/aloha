namespace WingtipToys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAspNetUsersField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UniversityID", c => c.String());
            AddColumn("dbo.AspNetUsers", "ManagerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ManagerID");
            DropColumn("dbo.AspNetUsers", "UniversityID");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
