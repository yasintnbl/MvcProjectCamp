namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_abilitypoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abilities", "AbiltyPoint", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abilities", "AbiltyPoint");
        }
    }
}
