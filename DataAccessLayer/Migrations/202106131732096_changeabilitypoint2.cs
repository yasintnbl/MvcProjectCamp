namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeabilitypoint2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abilities", "AbiltyPoint", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abilities", "AbiltyPoint", c => c.String());
        }
    }
}
