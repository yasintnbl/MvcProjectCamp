namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        AbiltyID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        AbiltyName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AbiltyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abilities");
        }
    }
}
