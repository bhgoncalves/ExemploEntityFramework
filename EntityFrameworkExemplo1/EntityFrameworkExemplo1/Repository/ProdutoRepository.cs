using System.Data.Entity;

namespace EntityFrameworkExemplo1.Repository
{
    public class ProdutoRepository
    {
        public int Save(Produto produto)
        {

            if (produto == null) return 0;

            using (var db = new ApplicationDBContext())
            {
                if (db.Entry(produto).State == EntityState.Detached)
                {
                    db.Set<Produto>().Attach(produto);
                }

                if (produto.Id == 0)
                {

                    db.Entry(produto).State = EntityState.Added;
                }
                else
                {
                    db.Entry(produto).State = EntityState.Modified;
                }

                return db.SaveChanges();
            }
        }

        public int Delete(Produto produto)
        {
            using (var db = new ApplicationDBContext())
            {
                if (db.Entry(produto).State == EntityState.Detached)
                    db.Set<Produto>().Attach(produto);
                db.Entry(produto).State = EntityState.Deleted;
                return db.SaveChanges();

            }
        }

    }
}
