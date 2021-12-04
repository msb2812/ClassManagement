namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingStatusTableData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status VALUES('Pending') ");
            Sql("INSERT INTO Status VALUES('Approve')");
            Sql("INSERT INTO Status VALUES('Reject')");
        }

        public override void Down()
        {
        }
    }
}
