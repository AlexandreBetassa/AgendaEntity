namespace AgendaEntityCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Mail = c.String(),
                        Numbers_Fix = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Phones", t => t.Numbers_Fix)
                .Index(t => t.Numbers_Fix);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Fix = c.String(nullable: false, maxLength: 128),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.Fix);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Numbers_Fix", "dbo.Phones");
            DropIndex("dbo.People", new[] { "Numbers_Fix" });
            DropTable("dbo.Phones");
            DropTable("dbo.People");
        }
    }
}
