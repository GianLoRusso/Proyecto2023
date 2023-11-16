using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql.Adapters
{
    public sealed class TipoProductoAdapter : IEntityAdapter<TipoProducto>
    {
        #region singleton
        private readonly static TipoProductoAdapter Instance = new TipoProductoAdapter();

        public static TipoProductoAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private TipoProductoAdapter()
        {

        }
        #endregion
        public TipoProducto Adapt(object[] values)
        {
            return new TipoProducto()
            {
                ID_TipodeProducto = int.Parse(values[0].ToString()),
                NombreCategoria = values[1].ToString(),
            };
        }
    }
}
