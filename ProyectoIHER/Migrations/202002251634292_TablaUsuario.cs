namespace ProyectoIHER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        ClienteRTN = c.String(nullable: false),
                        ClienteNombre = c.String(nullable: false, maxLength: 30),
                        ClienteApellido = c.String(nullable: false, maxLength: 30),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Correo = c.String(),
                        NacionalidadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.Nacionalidads", t => t.NacionalidadID, cascadeDelete: true)
                .Index(t => t.NacionalidadID);
            
            CreateTable(
                "dbo.Nacionalidads",
                c => new
                    {
                        NacionalidadID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NacionalidadID);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(),
                        Direccion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "NacionalidadID", "dbo.Nacionalidads");
            DropIndex("dbo.Clientes", new[] { "NacionalidadID" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.Nacionalidads");
            DropTable("dbo.Clientes");
        }
    }
}
