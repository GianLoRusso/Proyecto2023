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
    internal class VendedorRepository : IGenericRepository<Vendedor>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Vendedor] (Nombre, Contraseña) VALUE (@Nombre, @Contraseña)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Vendedor] SET (Nombre = @Nombre , Contraseña = @Contraseña) WHERE ID_Vendedor = @ID_Vendedor";
        }
        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Vendedor] WHERE ID_Vendedor = @ID_Vendedor";
        }
        private string SelectOneStatement
        {
            get => "SELECT ID_Vendedor, Nombre, Contraseña FROM [dbo].[Vendedor] WHERE ID_Vendedor = @ID_Vendedor";
        }
        private string SelectAllStatement
        {
            get => "SELECT ID_Vendedor, Nombre, Contraseña FROM [dbo].[Vendedor]";
        }
        #endregion

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vendedor> GetAll(string filterExpression)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return VendedorAdapter.Current.Adapt(values);
                }
            }
        }

        public Vendedor  GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_Vendedor", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                Vendedor vendedor = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    vendedor = VendedorAdapter.Current.Adapt(values);
                }

                return vendedor;
            }
        }

       

        public void Insert(Vendedor obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Nombre", obj.Nombre),
                new SqlParameter("@Contraseña",obj.Contraseña)
            });
                

            
        }

        public void Update(Vendedor obj)
        {
            throw new NotImplementedException();
        }
        

    }
}
