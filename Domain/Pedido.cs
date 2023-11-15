using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pedido
    {
        public Vendedor ID_Vendedor { get; set; }
        public int ID_Pedido { get; set; }
        public Cliente ID_Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
