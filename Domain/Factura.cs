using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Factura
    {
        public int ID_Factura { get; set; }
        public Pedido ID_Pedido { get; set; }
        public FormadePago ID_FormadePago { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
    }
}
