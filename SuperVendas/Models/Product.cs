using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVendas.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public bool InStock { get; set; }
    }
}
