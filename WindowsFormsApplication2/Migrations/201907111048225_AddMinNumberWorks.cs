namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinNumberWorks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "MinNumberWorkers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "MinNumberWorkers");
        }
    }
}
