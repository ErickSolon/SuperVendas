using SuperVendas.DbContextFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVendas.Controller
{
    public class ListaVendasController
    {
        private readonly AppDbContext _context;
        public ListaVendasController(AppDbContext context) 
        {
            _context = context;
        }

        public List<Models.ListaVendas> GetListaVendas()
        {
            return _context.ListaVendas.ToList();
        }
    }
}
