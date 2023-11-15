using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql.Adapters
{
    public sealed class Orden_de_pedidoAdapter : IEntityAdapter<Orden_de_pedido>
    {
        #region singleton 
        private readonly static Orden_de_pedidoAdapter Instance = new Orden_de_pedidoAdapter();

        public static Orden_de_pedidoAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private Orden_de_pedidoAdapter()
        {

        }
        #endregion
        public Orden_de_pedido Adapt(object[] values)
        {
            int Cliente = int.Parse(values[4].ToString());
            int Producto = int.Parse(values[5].ToString());
            int Vendedor = int.Parse(values[6].ToString());

            return new Orden_de_pedido()
            {
                Nro_Orden = int.Parse(values[0].ToString()),
                Cantidad = values[1].ToString(),
                Fecha_Creacion = DateTime.Parse(values[2].ToString()),
                Fecha_Entrega = DateTime.Parse(values[3].ToString()),
            };
        }
    }
}
