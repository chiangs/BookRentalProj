namespace BookRentalProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "ChargeRateSixMonth", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "CharRateSixMonth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "CharRateSixMonth", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "ChargeRateSixMonth");
        }
    }
}
