namespace DatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "User1Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "User2Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserPostedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserProfileId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "UserReceivedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "UserSentId", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "User1Id" });
            DropIndex("dbo.Friends", new[] { "User2Id" });
            DropIndex("dbo.Posts", new[] { "UserPostedId" });
            DropIndex("dbo.Posts", new[] { "UserProfileId" });
            DropIndex("dbo.FriendRequests", new[] { "UserSentId" });
            DropIndex("dbo.FriendRequests", new[] { "UserReceivedId" });
            AlterColumn("dbo.Friends", "User1Id", c => c.String());
            AlterColumn("dbo.Friends", "User2Id", c => c.String());
            AlterColumn("dbo.Posts", "UserPostedId", c => c.String());
            AlterColumn("dbo.Posts", "UserProfileId", c => c.String());
            AlterColumn("dbo.FriendRequests", "UserSentId", c => c.String());
            AlterColumn("dbo.FriendRequests", "UserReceivedId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FriendRequests", "UserReceivedId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FriendRequests", "UserSentId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "UserProfileId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "UserPostedId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Friends", "User2Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Friends", "User1Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FriendRequests", "UserReceivedId");
            CreateIndex("dbo.FriendRequests", "UserSentId");
            CreateIndex("dbo.Posts", "UserProfileId");
            CreateIndex("dbo.Posts", "UserPostedId");
            CreateIndex("dbo.Friends", "User2Id");
            CreateIndex("dbo.Friends", "User1Id");
            AddForeignKey("dbo.FriendRequests", "UserSentId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequests", "UserReceivedId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "UserProfileId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "UserPostedId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "User2Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "User1Id", "dbo.AspNetUsers", "Id");
        }
    }
}
