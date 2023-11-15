using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql.Adapters
{
    public sealed class VendedorAdapter : IEntityAdapter<Vendedor>
    {
        #region singleton
        private readonly static VendedorAdapter Instance = new VendedorAdapter();
        
        public static VendedorAdapter Current
        {
            get
            {
                return Instance;
            }
        }
        private VendedorAdapter()
        {

        }
        #endregion
        public Vendedor Adapt(object[] values)
        {
            return new Vendedor()
            {
                ID_Vendedor = int.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                Contraseña = values[2].ToString(),
            };
        }
    }
}
