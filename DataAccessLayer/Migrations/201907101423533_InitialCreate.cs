namespace WindowsFormsApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weekends",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstDate = c.DateTime(nullable: false),
                        SecontDate = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        TeamName = c.String(),
                        IndexDate = c.Boolean(nullable: false),
                        Peopleid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Peopleid, cascadeDelete: true)
                .Index(t => t.Peopleid);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Year = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        TeamName = c.String(),
                        Day = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "Peopleid", "dbo.People");
            DropIndex("dbo.Vacations", new[] { "Peopleid" });
            DropTable("dbo.People");
            DropTable("dbo.Vacations");
            DropTable("dbo.Weekends");
        }
    }
}
