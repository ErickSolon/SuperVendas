using SuperVendas.DbContextFiles;
using SuperVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVendas.Controller
{
    public class ListaProdutos
    {
        private readonly AppDbContext _context;
        public ListaProdutos(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts(int pagina = 1, int tamanho = 5)
        {
            return _context.products.Skip((pagina - 1) * tamanho).Take(tamanho).ToList();
        }

        public int TotalProducts()
        {
            return _context.products.Count();
        }

    }
}
