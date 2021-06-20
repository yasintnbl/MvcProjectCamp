namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriteTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriteTitle", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterTitle");
        }
    }
}
