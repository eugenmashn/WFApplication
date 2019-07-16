namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cascadedelete1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "TeamId", "dbo.Teams");
            AddForeignKey("dbo.People", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "TeamId", "dbo.Teams");
            AddForeignKey("dbo.People", "TeamId", "dbo.Teams", "Id");
        }
    }
}
