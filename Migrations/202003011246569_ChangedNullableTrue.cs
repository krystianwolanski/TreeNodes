namespace Tree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNullableTrue : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Nodes", new[] { "ParentId" });
            AlterColumn("dbo.Nodes", "ParentId", c => c.Int());
            CreateIndex("dbo.Nodes", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Nodes", new[] { "ParentId" });
            AlterColumn("dbo.Nodes", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Nodes", "ParentId");
        }
    }
}
