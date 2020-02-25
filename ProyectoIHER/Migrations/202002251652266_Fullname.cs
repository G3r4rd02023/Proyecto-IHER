namespace ProyectoIHER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fullname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: true, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: true));
        }
    }
}
