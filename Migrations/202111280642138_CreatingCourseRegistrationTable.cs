namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingCourseRegistrationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CourseId", "dbo.Courses");
            DropIndex("dbo.Users", new[] { "CourseId" });
            CreateTable(
                "dbo.CourseRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.StatusId);
            
            DropColumn("dbo.Users", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CourseRegistrations", "UserId", "dbo.Users");
            DropForeignKey("dbo.CourseRegistrations", "StatusId", "dbo.Status");
            DropForeignKey("dbo.CourseRegistrations", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseRegistrations", new[] { "StatusId" });
            DropIndex("dbo.CourseRegistrations", new[] { "CourseId" });
            DropIndex("dbo.CourseRegistrations", new[] { "UserId" });
            DropTable("dbo.CourseRegistrations");
            CreateIndex("dbo.Users", "CourseId");
            AddForeignKey("dbo.Users", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
