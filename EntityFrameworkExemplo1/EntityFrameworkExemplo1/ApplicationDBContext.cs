using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFrameworkExemplo1
{
    class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base(nameOrConnectionString: "entityframework"){}
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
