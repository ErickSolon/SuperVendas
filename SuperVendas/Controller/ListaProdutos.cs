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

        public void UpdateProduct(Product product)
        {
            var productToUpdate = _context.products.FirstOrDefault(x => x.Id == product.Id);

            productToUpdate.Name = product.Name;
            productToUpdate.Category = product.Category;
            productToUpdate.InStock = product.InStock;

            _context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var dado = _context.products.FirstOrDefault(x => x.Id == id);
            _context.Remove(dado);
            _context.SaveChanges();
        }
    }
}
