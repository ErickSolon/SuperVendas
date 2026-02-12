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

        private int pagina = 1;
        private int itensPorPagina = 5;
        public ListaVendas()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void CarregarPagina()
        {
            using (var db = new AppDbContext())
            {
                var service = new Controller.ListaProdutos(db);

                int totalItens = service.TotalProducts();
                int totalPaginas = (int)Math.Ceiling((double)totalItens / itensPorPagina);

                var lista = service.GetProducts(pagina, itensPorPagina);

                dataGridView1.DataSource = lista;

                label1.Text = $"Página {pagina} de {totalPaginas}";

                button1.Enabled = pagina > 1;                
                button2.Enabled = pagina < totalPaginas;     
            }
        }


        private void ListaVendas_Load(object sender, EventArgs e)
        {
            CarregarPagina();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarVenda AdicionarVenda = new AdicionarVenda();
            AdicionarVenda.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pagina++;
            CarregarPagina();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pagina--;
            CarregarPagina();
        }
    }
}
