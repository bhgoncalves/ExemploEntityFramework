using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExemplo1
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [MaxLength(100),Required]
        public string nome { get; set; }
    }
}
