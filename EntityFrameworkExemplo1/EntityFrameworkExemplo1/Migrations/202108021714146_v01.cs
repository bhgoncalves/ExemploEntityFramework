namespace EntityFrameworkExemplo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.idCategoria);
            
        }
        
        public override void Down()
        {
            DropTable("public.Categorias");
        }
    }
}
