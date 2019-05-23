namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AplicationDomains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        ServiceDisplayName = c.String(),
                        ServiceType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        MachiName = c.String(),
                        DateTimeUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.AplicationDomains");
        }
    }
}
