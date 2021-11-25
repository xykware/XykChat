namespace XykChat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_relationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Member", "Member_ID", "dbo.Member");
            DropForeignKey("dbo.MemberRoom", "Member_ID", "dbo.Member");
            DropForeignKey("dbo.MemberRoom", "Room_ID", "dbo.Room");
            DropIndex("dbo.Member", new[] { "Member_ID" });
            DropIndex("dbo.MemberRoom", new[] { "Member_ID" });
            DropIndex("dbo.MemberRoom", new[] { "Room_ID" });
            CreateTable(
                "dbo.Relationship",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        RoomID = c.Int(),
                        FriendID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Member", "Member_ID");
            DropTable("dbo.MemberRoom");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberRoom",
                c => new
                    {
                        Member_ID = c.Int(nullable: false),
                        Room_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_ID, t.Room_ID });
            
            AddColumn("dbo.Member", "Member_ID", c => c.Int());
            DropTable("dbo.Relationship");
            CreateIndex("dbo.MemberRoom", "Room_ID");
            CreateIndex("dbo.MemberRoom", "Member_ID");
            CreateIndex("dbo.Member", "Member_ID");
            AddForeignKey("dbo.MemberRoom", "Room_ID", "dbo.Room", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MemberRoom", "Member_ID", "dbo.Member", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Member", "Member_ID", "dbo.Member", "ID");
        }
    }
}
