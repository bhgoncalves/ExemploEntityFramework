using EntityFrameworkExemplo1.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkExemplo1
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                categoriaBindingSource.Add(new Categoria());
                categoriaBindingSource.MoveLast();
            }

            if (categoriaBindingSource.Current == null) return;


            using (var form = new FormCategoria(categoriaBindingSource.Current as Categoria))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var categoria = categoriaBindingSource.Current as Categoria;
                    if (new CategoriaRepository().Save(categoria) > 1)
                    {
                        dgvCategorias.Refresh();
                    }

                }
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            using (var db = new ApplicationDBContext())
            {
                categoriaBindingSource.DataSource = db.Categorias.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var categoria = categoriaBindingSource.Current as Categoria;
            if (categoria == null) return;

            if (MessageBox.Show("Deseja realmente excluir a categoria?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (new CategoriaRepository().Delete(categoria) > 0)
            {
                categoriaBindingSource.Remove(categoria);
                dgvCategorias.Refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sender == button6)
            {
                produtoBindingSource.Add(new Produto());
                produtoBindingSource.MoveLast();
            }

            if (produtoBindingSource.Current == null) return;


            using (var form = new FormProduto(produtoBindingSource.Current as Produto))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var produto = produtoBindingSource.Current as Produto;
                    if (new ProdutoRepository().Save(produto) > 1)
                    {
                        dgvCategorias.Refresh();
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var produto = produtoBindingSource.Current as Produto;
            if (produto == null) return;

            if (MessageBox.Show("Deseja realmente excluir a categoria?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (new ProdutoRepository().Delete(produto) > 0)
            {
                produtoBindingSource.Remove(produto);
                dgvCategorias.Refresh();
            }
        }
    }
}
