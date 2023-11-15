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
    public sealed class PedidoAdapter : IEntityAdapter<Pedido>
    {
        #region singleton
        private readonly static PedidoAdapter Instance = new PedidoAdapter();
        
        public static PedidoAdapter Current
        {
            get
            {
                return Instance;    
            }
        }

        private PedidoAdapter()
        {

        }
        #endregion

        public Pedido Adapt(object[] values)
        {
            int Vendedor = int.Parse(values[1].ToString());
            int Cliente = int.Parse(values[2].ToString());

            return new Pedido()
            {
                ID_Pedido = int.Parse(values[0].ToString()),
                Fecha = DateTime.Parse(values[3].ToString()),
                Estado = values[4].ToString(),

                ID_Vendedor = FactoryDAL.VendedorRepository.GetOne(Vendedor),
                ID_Cliente = FactoryDAL.ClienteRepository.GetOne(Cliente)
            };
        }
    }
}
