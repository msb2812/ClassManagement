namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Status");
        }
    }
}
