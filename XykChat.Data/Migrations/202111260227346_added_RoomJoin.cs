namespace XykChat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_RoomJoin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "Password");
        }
    }
}
