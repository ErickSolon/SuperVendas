using Microsoft.VisualBasic;
using SuperVendas.DbContextFiles;

namespace SuperVendas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var service = new Controller.Login(db);
                var lista = service.GetLogins();


                foreach (var item in lista)
                {
                    if (Usuario.Text == item.Usuario && Senha.Text == item.Senha)
                    {
                        ListaProdutos listaVendas = new ListaProdutos();
                        listaVendas.Show();
                        this.Hide();
                    } else
                    {
                        MessageBox.Show("Login Falhou");
                    }
                }
            }
        }
    }
}
