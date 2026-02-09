using SuperVendas.DbContextFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVendas.Controller
{
    public class Login
    {
        private readonly AppDbContext _context;

        public Login(AppDbContext context) {
            _context = context;
        }

        public List<Models.Login> GetLogins()
        {
            return _context.Login.ToList();
        }
    }
}
