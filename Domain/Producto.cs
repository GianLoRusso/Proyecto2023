using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Producto
    {
        public string Descripcion { get; set; }
        public int ID_Producto { get; set; }
        public int ID_TipodeProducto { get; set; }
        public string Nombre { get; set; }
        public int Precio_Mayorista { get; set; }
        public int Precio_Minorista { get; set; }

    }
}
