namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteability : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers");
            DropForeignKey("dbo.Writers", "Ability_AbiltyID", "dbo.Abilities");
            DropIndex("dbo.Abilities", new[] { "Writer_WriterID" });
            DropIndex("dbo.Writers", new[] { "Ability_AbiltyID" });
            DropColumn("dbo.Abilities", "Writer_WriterID");
            DropColumn("dbo.Writers", "AbiltyID");
            DropColumn("dbo.Writers", "Ability_AbiltyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Ability_AbiltyID", c => c.Int());
            AddColumn("dbo.Writers", "AbiltyID", c => c.Int(nullable: false));
            AddColumn("dbo.Abilities", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Writers", "Ability_AbiltyID");
            CreateIndex("dbo.Abilities", "Writer_WriterID");
            AddForeignKey("dbo.Writers", "Ability_AbiltyID", "dbo.Abilities", "AbiltyID");
            AddForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
