namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rm_isread_contact : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "IsRead");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
        }
    }
}
