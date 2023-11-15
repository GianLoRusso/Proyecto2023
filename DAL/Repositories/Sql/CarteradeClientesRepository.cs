using DAL.Contracts;
using DAL.Repositories.Sql.Adapters;
using DAL.Tools;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql
{
    internal class CarteradeClientesRepository : IGenericRepository<CarteradeClientes>
    {
        #region InsertStatement
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Cartera de clientes] (ID_Vendedor, ID_Cliente) VALUE (@ID_Vendedor, @ID_Cliente)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Cartera de clientes] SET (ID_Vendedor = @ID_Vendedor, ID_Cliente = @ID_Cliente) WHERE ID_Cartera = @ID_Cartera";
        }
        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Cartera de clientes] WHERE ID_Cartera = @ID_Cartera";
        }
        private string SelectOneStatement
        {
            get => "SELECT ID_Cartera, ID_Vendedor, ID_Cliente FROM [dbo].[Cartera de Clientes] WHERE ID_Cartera = @ID_Cartera";
        }
        private string SelectAllStatement
        {
            get => "SELECT ID_Cartera, ID_Vendedor, ID_Cliente FROM [dbo].[Cartera de clientes]";
        }
        #endregion

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarteradeClientes> GetAll(string filterExpression)
        {
            throw new NotImplementedException();
        }

        public CarteradeClientes GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_Cartera", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                CarteradeClientes carteradeclientes = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    carteradeclientes = CarteradeClientesAdapter.Current.Adapt(values);
                }

                return carteradeclientes;
            }
        }

        public void Insert(CarteradeClientes obj)
        {
            throw new NotImplementedException();
        }

        public void Update(CarteradeClientes obj)
        {
            throw new NotImplementedException();
        }
    }
}
