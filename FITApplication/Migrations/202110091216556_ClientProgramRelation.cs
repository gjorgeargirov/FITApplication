namespace FITApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientProgramRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramClients",
                c => new
                    {
                        Program_ProgramID = c.Int(nullable: false),
                        Client_ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Program_ProgramID, t.Client_ClientID })
                .ForeignKey("dbo.Programs", t => t.Program_ProgramID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID, cascadeDelete: true)
                .Index(t => t.Program_ProgramID)
                .Index(t => t.Client_ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramClients", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.ProgramClients", "Program_ProgramID", "dbo.Programs");
            DropIndex("dbo.ProgramClients", new[] { "Client_ClientID" });
            DropIndex("dbo.ProgramClients", new[] { "Program_ProgramID" });
            DropTable("dbo.ProgramClients");
        }
    }
}
