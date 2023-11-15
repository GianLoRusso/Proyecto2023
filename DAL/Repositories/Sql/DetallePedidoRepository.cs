using DAL.Contracts;
using DAL.Repositories.Sql.Adapters;
using DAL.Tools;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Sql
{
    internal class DetallePedidoRepository : IGenericRepository<DetallePedido>
    {
        #region Statements

        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[DetallePedido] (ID_Pedido, ID_Producto) VALUES (@ID_Pedido, @ID_Producto)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[DetallePedido] SET (ID_pedido = @ID_Pedido, ID_Producto = @ID_Producto) WHERE ID_DetallePedido = @ID_DetallePedido";
        }
        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[DetallePedido] WHERE ID_DetallePedido = @ID_DetallePedido";
        }
        private string SelectOneStatement
        {
            get => "SELECT ID_DetallePedido, ID_Pedido, ID_Producto FROM [dbo].[DetallePedido] WHERE ID_DetallePedido = @ID_DetallePedido";
        }
        private string SelectAllStatement
        {
            get => "SELECT ID_DetallePedido, ID_Pedido, ID_Producto FROM [dbo].[DetallePedido]";
        }
        #endregion

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetallePedido> GetAll(string filterExpression)
        {
            throw new NotImplementedException();
        }

        public DetallePedido GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_DetallePedido", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                DetallePedido detallePedido = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    detallePedido = DetallePedidoAdapter.Current.Adapt(values);
                }

                return detallePedido;
            }
        }

        public void Insert(DetallePedido obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@ID_Pedido", obj.ID_Pedido),
                new SqlParameter("@ID_Producto", obj.ID_Producto)
            });
        }

        public void Update(DetallePedido obj)
        {
            throw new NotImplementedException();
        }
    }
}
