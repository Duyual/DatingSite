namespace DatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oknowpls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    User1Id = c.String(maxLength: 128),
                    User2Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User1Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User2Id)
                .Index(t => t.User1Id)
                .Index(t => t.User2Id);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserPostedId = c.String(maxLength: 128),
                    UserProfileId = c.String(maxLength: 128),
                    Comment = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserPostedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserProfileId)
                .Index(t => t.UserPostedId)
                .Index(t => t.UserProfileId);

            CreateTable(
                "dbo.FriendRequests",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserSentId = c.String(maxLength: 128),
                    UserReceivedId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserReceivedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserSentId)
                .Index(t => t.UserSentId)
                .Index(t => t.UserReceivedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "UserSentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "UserReceivedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserProfileId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserPostedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "User2Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "User1Id", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequests", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.FriendRequests", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FriendRequests", new[] { "UserReceivedId" });
            DropIndex("dbo.FriendRequests", new[] { "UserSentId" });
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Posts", new[] { "UserProfileId" });
            DropIndex("dbo.Posts", new[] { "UserPostedId" });
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Friends", new[] { "User2Id" });
            DropIndex("dbo.Friends", new[] { "User1Id" });
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Posts");
            DropTable("dbo.Friends");
        }
    }
}
