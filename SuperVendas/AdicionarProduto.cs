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
    public partial class AdicionarProduto : Form
    {
        public AdicionarProduto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaProdutos ListaVendas = new ListaProdutos();
            ListaVendas.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var db = new AppDbContext())
            {
                var service = new Controller.ListaProdutos(db);

                Product product = new();
                product.Name = textBox1.Text;
                product.Category = textBox3.Text;
                product.InStock = checkBox1.Checked;

                service.AddProduct(product);
            }
                

        }
    }
}
