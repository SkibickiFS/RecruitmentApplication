using System;
using System.Data.Entity.Migrations;

public partial class InitMigrations : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Answers",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AnswerText = c.String(nullable: false, maxLength: 8000),
                    UserId = c.Int(nullable: false),
                    QuestionId = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
            .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
            .Index(t => t.UserId)
            .Index(t => t.QuestionId);
        
        CreateTable(
            "dbo.Questions",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Text = c.String(nullable: false, maxLength: 4000),
                    PositionId = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
            .Index(t => t.PositionId);
        
        CreateTable(
            "dbo.Positions",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 2147483647),
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "dbo.Users",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(maxLength: 2147483647),
                    Password = c.String(maxLength: 2147483647),
                    RoleId = c.Int(nullable: false),
                    PositionId = c.Int(),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Positions", t => t.PositionId)
            .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
            .Index(t => t.RoleId)
            .Index(t => t.PositionId);
        
        CreateTable(
            "dbo.Roles",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "dbo.Permissions",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "dbo.RolePermissions",
            c => new
                {
                    RoleId = c.Int(nullable: false),
                    PermissionId = c.Int(nullable: false),
                })
            .PrimaryKey(t => new { t.RoleId, t.PermissionId })
            .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
            .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
            .Index(t => t.RoleId)
            .Index(t => t.PermissionId);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.Answers", "UserId", "dbo.Users");
        DropForeignKey("dbo.Questions", "PositionId", "dbo.Positions");
        DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
        DropForeignKey("dbo.RolePermissions", "PermissionId", "dbo.Permissions");
        DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.Roles");
        DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
        DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
        DropIndex("dbo.RolePermissions", new[] { "PermissionId" });
        DropIndex("dbo.RolePermissions", new[] { "RoleId" });
        DropIndex("dbo.Users", new[] { "PositionId" });
        DropIndex("dbo.Users", new[] { "RoleId" });
        DropIndex("dbo.Questions", new[] { "PositionId" });
        DropIndex("dbo.Answers", new[] { "QuestionId" });
        DropIndex("dbo.Answers", new[] { "UserId" });
        DropTable("dbo.RolePermissions");
        DropTable("dbo.Permissions");
        DropTable("dbo.Roles");
        DropTable("dbo.Users");
        DropTable("dbo.Positions");
        DropTable("dbo.Questions");
        DropTable("dbo.Answers");
    }
}
