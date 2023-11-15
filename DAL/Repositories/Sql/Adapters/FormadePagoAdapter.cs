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
    public sealed class FormadePagoAdapter : IEntityAdapter<FormadePago>
    {
        #region singleton
        private readonly static FormadePagoAdapter Instance = new FormadePagoAdapter();

        public static FormadePagoAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private FormadePagoAdapter()
        {

        }
        #endregion

        public FormadePago Adapt(object[] values)
        {
            int Factura = int.Parse(values[2].ToString());

            return new FormadePago()
            {
                ID_FormaPago = int.Parse(values[1].ToString()),
                Descripcion = values[1].ToString(),

                ID_Factura=FactoryDAL.FacturaRepository.GetOne(Factura),
            };

        }
    }
}
