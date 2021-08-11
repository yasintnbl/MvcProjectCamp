namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_changed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "AbilityID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "AbilityID", c => c.Int(nullable: false));
        }
    }
}
