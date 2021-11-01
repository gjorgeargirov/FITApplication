namespace FITApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Height", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Height", c => c.Single(nullable: false));
            AlterColumn("dbo.Clients", "Weight", c => c.Single(nullable: false));
        }
    }
}
