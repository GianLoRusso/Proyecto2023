using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Orden_de_pedido
    {
        public string Cantidad { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public Cliente ID_Cliente { get; set; }
        public Producto ID_Producto { get; set; }
        public Vendedor ID_Vendedor { get; set; }
        public int Nro_Orden { get; set; }

    }
}
