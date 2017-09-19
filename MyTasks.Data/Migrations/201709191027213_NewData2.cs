namespace MyTasks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewData2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToDo", name: "AppUserFK", newName: "AppUserId");
            RenameIndex(table: "dbo.ToDo", name: "IX_AppUserFK", newName: "IX_AppUserId");
            AddColumn("dbo.User", "FullName", c => c.String(nullable: true));
            AlterColumn("dbo.User", "AppUserId", c => c.Long(nullable: false, identity:true));
            DropColumn("dbo.User", "UserFullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserFullName", c => c.String());
            AlterColumn("dbo.User", "AppUserId", c => c.Long(nullable: false, identity:true));
            DropColumn("dbo.User", "FullName");
            RenameIndex(table: "dbo.ToDo", name: "IX_AppUserId", newName: "IX_AppUserFK");
            RenameColumn(table: "dbo.ToDo", name: "AppUserId", newName: "AppUserFK");
        }
    }
}
