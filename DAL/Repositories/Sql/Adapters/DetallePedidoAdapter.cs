using DAL.Contracts;
using DAL.Factory;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql.Adapters
{
    internal class DetallePedidoAdapter : IEntityAdapter<DetallePedido>
    {
        #region singleton
        private readonly static DetallePedidoAdapter Instance = new DetallePedidoAdapter();

        public static DetallePedidoAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private DetallePedidoAdapter()
        {

        }
        #endregion

        public DetallePedido Adapt(object[] values)
        {
            int Pedido = int.Parse(values[1].ToString());
            int Producto = int.Parse(values[2].ToString());

            return new DetallePedido()
            {
                ID_DetallePedido = int.Parse(values[0].ToString()),

                ID_Pedido = FactoryDAL.PedidoRepository.GetOne(Pedido),
                ID_Producto = FactoryDAL.ProductoRepository.GetOne(Producto),
            };
        }
    }
}
