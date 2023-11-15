using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DetallePedido
    {
        public int ID_DetallePedido { get; set; }
        public Pedido ID_Pedido { get; set; }
        public Producto ID_Producto { get; set; }

    }
}
