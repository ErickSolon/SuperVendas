using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConsumidor.Models
{
    public class Product
    {
        public int id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public bool inStock { get; set; }
    }
}
