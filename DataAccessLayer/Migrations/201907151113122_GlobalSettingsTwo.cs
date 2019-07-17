namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlobalSettingsTwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlobalSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameCompany = c.String(),
                        VacationDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GlobalSettings");
        }
    }
}
