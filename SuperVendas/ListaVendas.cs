using SuperVendas.DbContextFiles;
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
    public partial class ListaVendas : Form
    {
        public ListaVendas()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ListaVendas_Load(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var service = new Controller.ListaVendasController(db);
                var lista = service.GetListaVendas();
                dataGridView1.DataSource = lista;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarVenda AdicionarVenda = new AdicionarVenda();
            AdicionarVenda.Show();
            this.Hide();
        }
    }
}
