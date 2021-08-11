namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abilityid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abilities", "Writer_WriterID", c => c.Int());
            AddColumn("dbo.Writers", "AbiltyID", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "Ability_AbiltyID", c => c.Int());
            CreateIndex("dbo.Abilities", "Writer_WriterID");
            CreateIndex("dbo.Writers", "Ability_AbiltyID");
            AddForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Writers", "Ability_AbiltyID", "dbo.Abilities", "AbiltyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Writers", "Ability_AbiltyID", "dbo.Abilities");
            DropForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Writers", new[] { "Ability_AbiltyID" });
            DropIndex("dbo.Abilities", new[] { "Writer_WriterID" });
            DropColumn("dbo.Writers", "Ability_AbiltyID");
            DropColumn("dbo.Writers", "AbiltyID");
            DropColumn("dbo.Abilities", "Writer_WriterID");
        }
    }
}
