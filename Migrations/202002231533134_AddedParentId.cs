namespace Tree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedParentId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Nodes", new[] { "Parent_Id" });
            RenameColumn(table: "dbo.Nodes", name: "Parent_Id", newName: "ParentId");
            AlterColumn("dbo.Nodes", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Nodes", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Nodes", new[] { "ParentId" });
            AlterColumn("dbo.Nodes", "ParentId", c => c.Int());
            RenameColumn(table: "dbo.Nodes", name: "ParentId", newName: "Parent_Id");
            CreateIndex("dbo.Nodes", "Parent_Id");
        }
    }
}
