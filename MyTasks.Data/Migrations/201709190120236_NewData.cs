namespace MyTasks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewData : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToDo", name: "User_Id", newName: "AppUserFK");
            RenameIndex(table: "dbo.ToDo", name: "IX_User_Id", newName: "IX_AppUserFK");
            DropPrimaryKey("dbo.ToDo");
            DropColumn("dbo.ToDo", "ToDoID");
            DropColumn("dbo.ToDo", "UserId");
            DropColumn("dbo.User", "UserId");
            AddColumn("dbo.ToDo", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.User", "AppUserId", c => c.Long(identity: true));
            AddPrimaryKey("dbo.ToDo", "Id");
            
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDo", "Id");
            DropPrimaryKey("dbo.ToDo");
            DropColumn("dbo.User", "AppUserId");
            AddColumn("dbo.User", "UserId", c => c.Int(identity: true));
            AddColumn("dbo.ToDo", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.ToDo", "ToDoID", c => c.Long(nullable: false, identity: true));
            
            AddPrimaryKey("dbo.ToDo", "ToDoID");
            RenameIndex(table: "dbo.ToDo", name: "IX_AppUserFK", newName: "IX_User_Id");
            RenameColumn(table: "dbo.ToDo", name: "AppUserFK", newName: "User_Id");
        }
    }
}
