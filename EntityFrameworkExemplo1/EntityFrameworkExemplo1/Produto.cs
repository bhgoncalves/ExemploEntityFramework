using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkExemplo1
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public virtual Categoria Categoria { get; set; }

        public double Preco { get; set; }
        public string Nome { get; set; }
    }
}
