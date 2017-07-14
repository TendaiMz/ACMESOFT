namespace ACME_REPOSITORY.MSSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        EmployeeNumber = c.String(nullable: false, maxLength: 16),
                        EmployedDate = c.DateTime(nullable: false),
                        TerminatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "PersonId", "dbo.Person");
            DropIndex("dbo.Employee", new[] { "PersonId" });
            DropTable("dbo.Person");
            DropTable("dbo.Employee");
        }
    }
}
