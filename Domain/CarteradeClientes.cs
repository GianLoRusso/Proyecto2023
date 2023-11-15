using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CarteradeClientes
    {
        public int ID_Cartera { get; set; }
        public Vendedor ID_Vendedor { get; set; }
        public Cliente ID_Cliente { get; set; }
    }
}
