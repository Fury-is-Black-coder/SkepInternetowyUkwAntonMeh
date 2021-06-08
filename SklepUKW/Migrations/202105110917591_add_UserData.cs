namespace SklepUKW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_UserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_City", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_PhoneNumber");
            DropColumn("dbo.AspNetUsers", "UserData_Email");
            DropColumn("dbo.AspNetUsers", "UserData_City");
            DropColumn("dbo.AspNetUsers", "UserData_Address");
            DropColumn("dbo.AspNetUsers", "UserData_Surname");
            DropColumn("dbo.AspNetUsers", "UserData_Name");
        }
    }
}
