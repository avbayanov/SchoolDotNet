namespace Phonebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetStringsNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(maxLength: 30));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(maxLength: 100));
        }
    }
}
