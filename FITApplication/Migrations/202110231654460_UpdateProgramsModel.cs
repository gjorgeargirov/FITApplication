namespace FITApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProgramsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "Creator");
        }
    }
}
