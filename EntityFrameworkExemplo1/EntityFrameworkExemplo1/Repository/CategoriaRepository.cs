using System;
using System.Data.Entity;

namespace EntityFrameworkExemplo1.Repository
{
    public class CategoriaRepository 
    {
        public int Save(Categoria categoria) 
        {

            if (categoria == null) return 0;

            using (var db = new ApplicationDBContext())
            {
                if (db.Entry(categoria).State == EntityState.Detached)
                {
                    db.Set<Categoria>().Attach(categoria);
                }

                if (categoria.idCategoria == 0)
                {

                    db.Entry(categoria).State = EntityState.Added;
                }
                else
                {
                    db.Entry(categoria).State = EntityState.Modified;
                }

                return db.SaveChanges();
            }
        }

        public int Delete(Categoria categoria)
        {
            using (var db = new ApplicationDBContext())
            {
                if (db.Entry(categoria).State == EntityState.Detached)
                    db.Set<Categoria>().Attach(categoria);
                db.Entry(categoria).State = EntityState.Deleted;
                return db.SaveChanges();

            }
        }

    }
}
