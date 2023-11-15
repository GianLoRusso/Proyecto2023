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
    internal class FormadePagoRepository : IGenericRepository<FormadePago>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Forma de Pago] (Descripcion, ID_Factura) VALUES ( @SDescripcion,@ID_Factura)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Forma de Pago] SET (Descripcion = @Descripcion, Id_Factura = @ID_Factura) WHERE ID_FormaPago = @ID_FormaPago";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Forma de Pago] WHERE ID_FormaPago = @ID_FormaPago";
        }

        private string SelectOneStatement
        {
            get => "SELECT ID_FormaPago, Descripcion, ID_Factura FROM [dbo].[Forma de Pago] WHERE  ID_FormaPago  = @ID_FormaPago";
        }

        private string SelectAllStatement
        {
            get => "SELECT ID_FormaPago, Descripcion, ID_Factura FROM [dbo].[Forma de Pago]";
        }
        #endregion

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormadePago> GetAll(string filterExpression = null)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return FormadePagoAdapter.Current.Adapt(values);
                }
            }
        }

        public FormadePago GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_FormaPago", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                FormadePago formadepago = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    formadepago = FormadePagoAdapter.Current.Adapt(values);
                }

                return formadepago;
            }
        }

        public void Insert(FormadePago obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@Descripcion", obj.Descripcion),
                new SqlParameter ("@ID_Facutra",obj.ID_Factura)
            });
        }

        public void Update(FormadePago obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@Descripcion", obj.Descripcion),
                new SqlParameter ("@ID_Facutra",obj.ID_Factura)
            });
        }
    }
}
