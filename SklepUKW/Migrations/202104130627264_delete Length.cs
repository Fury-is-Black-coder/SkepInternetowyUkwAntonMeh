namespace SklepUKW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteLength : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Films", "Length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Length", c => c.Int(nullable: false));
        }
    }
}
