namespace DatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trori : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.FriendRequests", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FriendRequests", new[] { "ApplicationUser_Id1" });
            DropTable("dbo.Friends");
            DropTable("dbo.Posts");
            DropTable("dbo.FriendRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserSentId = c.String(),
                        UserReceivedId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserPostedId = c.String(),
                        UserProfileId = c.String(),
                        Comment = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User1Id = c.String(),
                        User2Id = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FriendRequests", "ApplicationUser_Id1");
            CreateIndex("dbo.FriendRequests", "ApplicationUser_Id");
            CreateIndex("dbo.Posts", "ApplicationUser_Id1");
            CreateIndex("dbo.Posts", "ApplicationUser_Id");
            CreateIndex("dbo.Friends", "ApplicationUser_Id1");
            CreateIndex("dbo.Friends", "ApplicationUser_Id");
            AddForeignKey("dbo.FriendRequests", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequests", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
