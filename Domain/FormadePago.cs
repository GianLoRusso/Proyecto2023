using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FormadePago
    {
        public int ID_FormaPago { get; set; }
        public string Descripcion { get; set; }
        public Factura ID_Factura { get; set; }

    }
}
