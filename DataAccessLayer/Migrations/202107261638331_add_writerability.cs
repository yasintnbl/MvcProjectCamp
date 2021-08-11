namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writerability : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Writers", "Ability_AbiltyID", "dbo.Abilities");
            DropIndex("dbo.Writers", new[] { "Ability_AbiltyID" });
            AddColumn("dbo.Abilities", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Abilities", "Writer_WriterID");
            AddForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers", "WriterID");
            DropColumn("dbo.Writers", "AbilityID");
            DropColumn("dbo.Writers", "Ability_AbiltyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Ability_AbiltyID", c => c.Int());
            AddColumn("dbo.Writers", "AbilityID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Abilities", new[] { "Writer_WriterID" });
            DropColumn("dbo.Abilities", "Writer_WriterID");
            CreateIndex("dbo.Writers", "Ability_AbiltyID");
            AddForeignKey("dbo.Writers", "Ability_AbiltyID", "dbo.Abilities", "AbiltyID");
        }
    }
}
