using System;
using System.Data.Entity.Migrations;

public partial class Init : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Answers",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    QuestionText = c.String(maxLength: 2147483647),
                    AnswerText = c.String(nullable: false, maxLength: 500),
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
            "dbo.Roles",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "dbo.Questions",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Text = c.String(nullable: false, maxLength: 500),
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
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
            .Index(t => t.RoleId);
        
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
        DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
        DropForeignKey("dbo.RolePermissions", "PermissionId", "dbo.Permissions");
        DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.Roles");
        DropIndex("dbo.RolePermissions", new[] { "PermissionId" });
        DropIndex("dbo.RolePermissions", new[] { "RoleId" });
        DropIndex("dbo.Users", new[] { "RoleId" });
        DropTable("dbo.RolePermissions");
        DropTable("dbo.Users");
        DropTable("dbo.Questions");
        DropTable("dbo.Roles");
        DropTable("dbo.Permissions");
        DropTable("dbo.Answers");
    }
}
