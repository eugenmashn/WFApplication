namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sqlquery : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.People ADD CONSTRAINT Peoples_Teams FOREIGN KEY (TeamId) REFERENCES dbo.Teams (Id) ON DELETE SET NULL");
        }
        
        public override void Down()
        {
        }
    }
}
