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
    public sealed class FacturaAdapter : IEntityAdapter<Factura>
    {
        #region singleton
        private readonly static FacturaAdapter Instance = new FacturaAdapter();

        public static FacturaAdapter Current
        {
            get
            {
                return Instance;
            }
        }
        private FacturaAdapter()
        {

        }
        #endregion
        public Factura Adapt(object[] values)
        {
            int Pedido = int.Parse(values[1].ToString());
            int FormaPago= int.Parse(values[2].ToString());

            return new Factura()
            {
                ID_Factura = int.Parse(values[0].ToString()),
                Fecha = DateTime.Parse(values[3].ToString()),
                Monto = int.Parse(values[4].ToString()),

                ID_Pedido = FactoryDAL.PedidoRepository.GetOne(Pedido),
                ID_FormadePago = FactoryDAL.FormadePagoRepository.GetOne(FormaPago),
            };
        }
    }
}
