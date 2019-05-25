namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableNguoiDung : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguoiDung", "AnhDaiDien", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiDung", "AnhDaiDien");
        }
    }
}
