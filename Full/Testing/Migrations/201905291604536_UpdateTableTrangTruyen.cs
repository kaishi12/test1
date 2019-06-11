namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableTrangTruyen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrangTruyen", "UrlAnh", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrangTruyen", "UrlAnh", c => c.Binary(nullable: false));
        }
    }
}
