namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Days", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Day", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Days");
        }
    }
}
