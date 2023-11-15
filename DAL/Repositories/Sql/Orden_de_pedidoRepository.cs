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
    internal class Orden_de_pedidoRepository : IGenericRepository<Orden_de_pedido>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Orden_de_pedido] (Cantidad, Fecha_Creacion, Fecha_Entrega, ID_Cliente, ID_Producto, ID_Vendedor) VALUES ( @Cantidad, @Fecha_Creacion, @Fecha_Entrega, @ID_Cliente, @ID_Producto, @ID_Vendedor)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Orden_de_pedido] SET (Cantidad = @Cantidad, Fecha_Creacion = @Fecha_Creacion, ID_Cliente =@ID_Cliente, ID_Producto =@ID_Producto, ID_Vendedor=@ID_Vendedor) WHERE Nro_Orden = @Nro_Orden";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Orden_de_pedido] WHERE Nro_Orden = @Nro_Orden";
        }

        private string SelectOneStatement
        {
            get => "SELECT Nro_Orden, Cantidad, Fecha_Creacion, Fecha_Entrega, ID_Cliente, ID_Producto, ID_Vendedor FROM [dbo].[Orden_de_pedido] WHERE  Nro_Orden  = @Nro_Orden";
        }

        private string SelectAllStatement
        {
            get => "SELECT Nro_Orden, Cantidad, Fecha_Creacion, Fecha_Entrega, ID_Cliente, ID_Producto, ID_Vendedor FROM [dbo].[Orden_de_pedido]";
        }
        #endregion
        

        public IEnumerable<Orden_de_pedido> GetAll(string filterExpression)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return Orden_de_pedidoAdapter.Current.Adapt(values);
                }
            }
        }

        public Orden_de_pedido GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@Nro_Orden", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                Orden_de_pedido ordendepedido = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    ordendepedido = Orden_de_pedidoAdapter.Current.Adapt(values);
                }

                return ordendepedido;
            }
        }

        public void Insert(Orden_de_pedido obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@Cantidad", obj.Cantidad),
                new SqlParameter ("@Fecha_Creacion", obj.Fecha_Creacion),
                new SqlParameter ("@Fecha_Entrega",obj.Fecha_Entrega)
            });
        }

        public void Update(Orden_de_pedido obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@Cantidad", obj.Cantidad),
                new SqlParameter ("@Fecha_Creacion", obj.Fecha_Creacion),
                new SqlParameter ("@Fecha_Entrega",obj.Fecha_Entrega)
            });
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
