namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "TeamId", c => c.Guid(nullable: true));
            CreateIndex("dbo.People", "TeamId");
            AddForeignKey("dbo.People", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
            DropColumn("dbo.People", "TeamName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "TeamName", c => c.String());
            DropForeignKey("dbo.People", "TeamId", "dbo.Teams");
            DropIndex("dbo.People", new[] { "TeamId" });
            DropColumn("dbo.People", "TeamId");
        }
    }
}
