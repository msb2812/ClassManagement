namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingRoleId : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles VALUES('Guest')");
        }
        
        public override void Down()
        {
        }
    }
}
