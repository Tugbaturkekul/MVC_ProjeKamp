namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_hashsorunoldusildim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminUserNameHash");
            DropColumn("dbo.Admins", "AdminPasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminUserNameHash", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Admins", "AdminUserName");
        }
    }
}
