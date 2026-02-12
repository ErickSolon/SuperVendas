using SuperVendas.DbContextFiles;
using SuperVendas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVendas
{
    public partial class EditProdutoDataview : Form
    {
        Product _product;
        public EditProdutoDataview(Product product)
        {
            InitializeComponent();
            _product = product;
            CarregarDados();
        }

        private void CarregarDados()
        {
            textBox1.Text = _product.Name;
            textBox2.Text = _product.Category;
            checkBox1.Checked = _product.InStock;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var service = new Controller.ListaProdutos(db);
                _product.Name = textBox1.Text;
                _product.Category = textBox2.Text;
                _product.InStock = checkBox1.Checked;

                service.UpdateProduct(_product);
                ListaProdutos listaVendas = new ListaProdutos();
                listaVendas.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaProdutos ListaVendas = new ListaProdutos();
            ListaVendas.Show();
            this.Hide();
        }
    }
}
