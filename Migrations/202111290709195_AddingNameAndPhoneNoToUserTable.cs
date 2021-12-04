namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNameAndPhoneNoToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Name");
        }
    }
}
