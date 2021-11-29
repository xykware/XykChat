namespace XykChat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_member : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "SenderID", "dbo.Member");
            DropPrimaryKey("dbo.Member");
            AddPrimaryKey("dbo.Member", "UserID");
            CreateIndex("dbo.Message", "SenderID");
            AddForeignKey("dbo.Message", "SenderID", "dbo.Member", "UserID", cascadeDelete: true);
            DropColumn("dbo.Member", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Message", "SenderID", "dbo.Member");
            DropIndex("dbo.Message", new[] { "SenderID" });
            DropPrimaryKey("dbo.Member");
            AddPrimaryKey("dbo.Member", "ID");
            AddForeignKey("dbo.Message", "SenderID", "dbo.Member", "UserID", cascadeDelete: true);
        }
    }
}
