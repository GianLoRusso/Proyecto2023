using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql.Adapters
{
    public sealed class ClienteAdapter : IEntityAdapter<Cliente>
    {
        #region Singleton
        private readonly static ClienteAdapter Instance = new ClienteAdapter();
        public static ClienteAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private ClienteAdapter()
        {

        }
        #endregion
        public Cliente Adapt(object[] values)
        {
            return new Cliente()
            {
                ID_Cliente = int.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                Correo = values[2].ToString(),
                Direccion = values[3].ToString(),
                Telefono = int.Parse(values[4].ToString())
            };
        }
    }
}
