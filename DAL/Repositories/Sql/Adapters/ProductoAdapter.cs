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
    public sealed class ProductoAdapter : IEntityAdapter<Producto>
    {
        #region singleton
        private readonly static ProductoAdapter Instance = new ProductoAdapter();

        public static ProductoAdapter Current
        {
            get
            {
                return Instance;
            }
        }
        private ProductoAdapter()
        {

        }
        #endregion

        public Producto Adapt(object[] values)
        {
            
            return new Producto()
            {
                ID_Producto = int.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                Descripcion = values[2].ToString(),
                Precio_Mayorista = int.Parse(values[3].ToString()),
                Precio_Minorista = int.Parse(values[4].ToString()),

                //adaptarr con TipodeProducto
                ID_TipodeProducto = int.Parse(values[5].ToString()),

                

            };

        }
    }
}
