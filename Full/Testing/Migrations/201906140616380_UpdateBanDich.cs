namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBanDich : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BanDich", "TenBanDich");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BanDich", "TenBanDich", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
