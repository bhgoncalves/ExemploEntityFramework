namespace EntityFrameworkExemplo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v03 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "public.Categorias", newName: "Categoria");
            CreateTable(
                "public.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategoria = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Categoria", t => t.IdCategoria, cascadeDelete: true)
                .Index(t => t.IdCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Produto", "IdCategoria", "public.Categoria");
            DropIndex("public.Produto", new[] { "IdCategoria" });
            DropTable("public.Produto");
            RenameTable(name: "public.Categoria", newName: "Categorias");
        }
    }
}
