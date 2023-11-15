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
    internal class PedidoRepository : IGenericRepository<Pedido>
    {
        #region Statements

        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Pedido] (ID_Vendedor, ID_Cliente, Fecha, Estado) VALUES (@ID_Vendedor, @ID_Cliente, @Fecha, @Estado)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Pedido] SET (ID_Vendedor = @ID_Vendedor, ID_Cliente = @ID_Cliente, Fecha = @Fecha, Estado = @Estado) WHERE ID_Pedido = @ID_Pedido";
        }
        private string DeleteStatement
        {
            get => " DELETE FROM [dbo].[Pedido] WHERE ID_Pedido = @ID_Pedido";
        }
        private string SelectOneStatement
        {
            get => "SELECT ID_Pedido, ID_Vendedor, ID_Cliente, Fecha, Estado FROM [dbo].[Pedido] WHERE ID_Pedido = @ID_Pedido";
        }
        private string SelectAllStatement
        {
            get => "SELECT ID_Pedido, ID_Vendedor, ID_Cliente, Fecha, Estado FROM [dbo].[Pedido]";
        }
        #endregion

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetAll(string filterExpression)
        {
            throw new NotImplementedException();
        }

        public Pedido GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_Pedido", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                Pedido pedido = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    pedido = PedidoAdapter.Current.Adapt(values);
                }

                return pedido;
            }
         }

            public void Insert(Pedido obj)
            {
                throw new NotImplementedException();
            }

            public void Update(Pedido obj)
            {
                throw new NotImplementedException();
            }
        }
    
  }
