namespace SklepUKW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_PosterName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "PosterName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "PosterName");
        }
    }
}
