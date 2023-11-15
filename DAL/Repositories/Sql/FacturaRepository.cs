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
    internal class FacturaRepository : IGenericRepository<Factura>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Factura] (ID_Pedido, ID_FormaPago, Fecha, Monto) VALUES ( @ID_Pedido, @ID_FormaPago, @Fecha, @Monto)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Factura] SET (ID_Pedido = @ID_Pedido, ID_FormaPago = @ID_FormaPago, Fecha=@Fecha, Monto=@Monto) WHERE ID_Factura = @ID_Factura";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Factura] WHERE ID_Factura = @ID_Factura";
        }

        private string SelectOneStatement
        {
            get => "SELECT ID_Factura, ID_Pedido, ID_FormaPago, Fecha, Monto FROM [dbo].[Factura] WHERE  ID_Factura  = @ID_Factura";
        }

        private string SelectAllStatement
        {
            get => "SELECT ID_Factura, ID_Pedido, ID_FormaPago, Fecha, Monto FROM [dbo].[Factura]";
        }
        #endregion

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> GetAll(string filterExpression)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return FacturaAdapter.Current.Adapt(values);
                }
            }
        }

        public Factura GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_Factura", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                Factura factura = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    factura = FacturaAdapter.Current.Adapt(values);
                }

                return factura;
            }
        }

        public void Insert(Factura obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@ID_Pedido", obj.ID_Pedido),
                new SqlParameter ("@ID_FormaPago", obj.ID_FormadePago),
                new SqlParameter ("@Fecha", obj.Fecha),
                new SqlParameter ("@Monto",obj.Monto)
            });
        }

        public void Update(Factura obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@ID_Pedido", obj.ID_Pedido),
                new SqlParameter ("@ID_FormaPago", obj.ID_FormadePago),
                new SqlParameter ("@Fecha", obj.Fecha),
                new SqlParameter ("@Monto",obj.Monto)
            });
        }
    }
}
