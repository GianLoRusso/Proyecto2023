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
    public sealed class CarteradeClientesAdapter : IEntityAdapter<CarteradeClientes>
    {
        #region singleton
        private readonly static CarteradeClientesAdapter Instance = new CarteradeClientesAdapter();

        public static CarteradeClientesAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private CarteradeClientesAdapter()
        {

        }
        #endregion

        public CarteradeClientes Adapt(object[] values)
        {
            int Vendedor = int.Parse(values[1].ToString());
            int Cliente = int.Parse(values[2].ToString());

            return new CarteradeClientes()
            {
                ID_Cartera = int.Parse(values[0].ToString()),

                ID_Cliente = FactoryDAL.ClienteRepository.GetOne(Cliente),
                ID_Vendedor = FactoryDAL.VendedorRepository.GetOne(Vendedor),
            };
        }
    }
}
