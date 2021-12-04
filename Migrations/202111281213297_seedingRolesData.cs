namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingRolesData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Title", c => c.String());
            Sql("INSERT INTO Roles VALUES('Admin')");
            Sql("INSERT INTO Roles VALUES('User')");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Title", c => c.Int(nullable: false));
        }
    }
}
