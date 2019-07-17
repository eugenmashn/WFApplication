namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteYearinTeam : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teams", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Year", c => c.Int(nullable: false));
        }
    }
}
