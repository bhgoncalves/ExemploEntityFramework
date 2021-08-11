namespace EntityFrameworkExemplo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v011 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Produto", "IdCategoria", "public.Categoria");
            DropIndex("public.Produto", new[] { "IdCategoria" });
            RenameColumn(table: "public.Produto", name: "IdCategoria", newName: "Categoria_idCategoria");
            AlterColumn("public.Produto", "Categoria_idCategoria", c => c.Int());
            CreateIndex("public.Produto", "Categoria_idCategoria");
            AddForeignKey("public.Produto", "Categoria_idCategoria", "public.Categoria", "idCategoria");
        }
        
        public override void Down()
        {
            DropForeignKey("public.Produto", "Categoria_idCategoria", "public.Categoria");
            DropIndex("public.Produto", new[] { "Categoria_idCategoria" });
            AlterColumn("public.Produto", "Categoria_idCategoria", c => c.Int(nullable: false));
            RenameColumn(table: "public.Produto", name: "Categoria_idCategoria", newName: "IdCategoria");
            CreateIndex("public.Produto", "IdCategoria");
            AddForeignKey("public.Produto", "IdCategoria", "public.Categoria", "idCategoria", cascadeDelete: true);
        }
    }
}
