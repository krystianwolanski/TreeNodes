namespace Tree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nodes", "Parent_Id", c => c.Int());
            CreateIndex("dbo.Nodes", "Parent_Id");
            AddForeignKey("dbo.Nodes", "Parent_Id", "dbo.Nodes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nodes", "Parent_Id", "dbo.Nodes");
            DropIndex("dbo.Nodes", new[] { "Parent_Id" });
            DropColumn("dbo.Nodes", "Parent_Id");
        }
    }
}
