namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_ability : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Abilities", new[] { "Writer_WriterID" });
            DropColumn("dbo.Abilities", "Writer_WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abilities", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Abilities", "Writer_WriterID");
            AddForeignKey("dbo.Abilities", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
