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
    public partial class AdicionarVenda : Form
    {
        public AdicionarVenda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaVendas ListaVendas = new ListaVendas();
            ListaVendas.Show();
            this.Hide();
        }
    }
}
