using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkExemplo1
{
    public partial class FormProduto : Form
    {
        Produto prod;
        public FormProduto(Produto produto)
        {
            prod = produto;
            InitializeComponent();
        }

        private void FormProduto_Load(object sender, System.EventArgs e)
        {
            textBox1.DataBindings.Add("Text", prod, "Id");
            textBox2.DataBindings.Add("Text", prod, "Nome");
            categoriaBindingSource.DataSource = new ApplicationDBContext().Categorias.ToList();
            selecionaCategoriaAtual();
        }

        private void selecionaCategoriaAtual()
        {
            foreach (var item  in comboBox1.Items)
            {
                var produto = item as Produto;
                if (produto is null) return;
                if (produto.Categoria.idCategoria == prod.Categoria.idCategoria)
                {
                    comboBox1.SelectedItem = item;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            prod.Categoria = comboBox1.SelectedItem as Categoria;
        }
    }
}
