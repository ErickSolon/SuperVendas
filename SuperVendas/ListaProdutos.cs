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
    public partial class ListaProdutos : Form
    {

        private int pagina = 1;
        private int itensPorPagina = 5;
        public ListaProdutos()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
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

                // Início botão para deletar a linha
                DataGridViewButtonColumn dataGridViewButtonColumn = new();
                if (!dataGridView1.Columns.Contains("Deletar"))
                {
                    
                    dataGridViewButtonColumn.Name = "Deletar";
                    dataGridViewButtonColumn.HeaderText = "Ação";
                    dataGridViewButtonColumn.Text = "Deletar";
                    dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(dataGridViewButtonColumn);
                }
                // Fim botão para deletar a linha

                dataGridView1.DataSource = lista;
                dataGridViewButtonColumn.DisplayIndex = dataGridView1.Columns.Count - 1;

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
            AdicionarProduto AdicionarVenda = new AdicionarProduto();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name != "Deletar")
            {
                var produto = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                EditProdutoDataview editProdutoDataview = new(produto);
                editProdutoDataview.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Deletar")
            {
                using (var db = new AppDbContext())
                {
                    var service = new Controller.ListaProdutos(db);
                    var dadosColuna = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    var confirm = MessageBox.Show($"Deseja apagar mesmo o item de Id {dadosColuna.Id}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        service.DeleteProduct(dadosColuna.Id);
                        CarregarPagina();
                    }
                }

            }
        }

    }
}
