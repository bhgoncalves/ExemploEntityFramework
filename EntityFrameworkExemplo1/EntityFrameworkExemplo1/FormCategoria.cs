using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkExemplo1
{
    public partial class FormCategoria : Form
    {
        private Categoria categoria;
        public FormCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add(new Binding("Text", this.categoria, "idCategoria"));
            textBox2.DataBindings.Add(new Binding("Text", this.categoria, "nome"));
        }
    }
}
