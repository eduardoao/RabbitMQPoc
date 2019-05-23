namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AplicationDomains", newName: "AplicationDomain");
            DropTable("dbo.Usuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameTable(name: "dbo.AplicationDomain", newName: "AplicationDomains");
        }
    }
}
