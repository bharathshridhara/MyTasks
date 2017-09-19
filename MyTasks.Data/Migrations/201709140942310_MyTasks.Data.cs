namespace MyTasks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyTasksData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.User_Role",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.ToDo",
                c => new
                    {
                        ToDoID = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ToDoID)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserId = c.Int(identity: true),
                        Internal = c.Boolean(),
                        UserFullName = c.String(),
                        UserEmail = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.User_Claim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.User_Login",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Role", "IdentityUser_Id", "dbo.User");
            DropForeignKey("dbo.User_Login", "IdentityUser_Id", "dbo.User");
            DropForeignKey("dbo.User_Claim", "IdentityUser_Id", "dbo.User");
            DropForeignKey("dbo.ToDo", "User_Id", "dbo.User");
            DropForeignKey("dbo.User_Role", "RoleId", "dbo.Roles");
            DropIndex("dbo.User_Login", new[] { "IdentityUser_Id" });
            DropIndex("dbo.User_Claim", new[] { "IdentityUser_Id" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.ToDo", new[] { "User_Id" });
            DropIndex("dbo.User_Role", new[] { "IdentityUser_Id" });
            DropIndex("dbo.User_Role", new[] { "RoleId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.User_Login");
            DropTable("dbo.User_Claim");
            DropTable("dbo.User");
            DropTable("dbo.ToDo");
            DropTable("dbo.User_Role");
            DropTable("dbo.Roles");
        }
    }
}
