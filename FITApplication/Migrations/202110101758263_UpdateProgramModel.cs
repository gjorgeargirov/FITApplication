namespace FITApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProgramModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "Description");
        }
    }
}
