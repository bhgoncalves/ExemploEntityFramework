using ExemploEntityFramework.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploEntityFramework
{
    public partial class FormCategoria : Form
    {
        Categoria categoria1;
        public FormCategoria(Categoria categoria)
        {
            InitializeComponent();
            categoria1 = categoria;
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add("Text", categoria1, "Id");
            textBox2.DataBindings.Add("Text", categoria1, "Nome");
        }
    }
}
