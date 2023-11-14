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
        public int ID_Cliente { get; set; }
        public int ID_Producto { get; set; }
        public int ID_Vendedor { get; set; }
        public int Nro_Orden { get; set; }

    }
}
