namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_aboutstatus_aboutheading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutHeading", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutStatus");
            DropColumn("dbo.Abouts", "AboutHeading");
        }
    }
}
