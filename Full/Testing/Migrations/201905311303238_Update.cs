namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuongTruyen", "ThuTuChuong", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuongTruyen", "ThuTuChuong", c => c.Int());
        }
    }
}
