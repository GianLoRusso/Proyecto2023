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
    internal class ClienteRepository : IGenericRepository<Cliente>
    {
        #region Statements 
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Cliente] (Nombre, Correo, Direccion, Telefono) VALUES (@Nombre, @Correo, @Direccion, @Telefono)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Cliente] SET (Nombre = @Nombre , Correo = @Correo , Direccion = @Direccion, Telefono = @Telefono) WHERE ID_Cliente = @ID_Cliente";
        }
        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Cliente] WHERE ID_Cliente = @ID_Cliente";
        }
        private string SelectOneStatement
        {
            get => "SELECT ID_Cliente, Nombre, Correo, Direccion, Telefono FROM [dbo].[Cliente] WHERE ID_Cliente = @ID_Cliente";
        }
        private string SelectAllStatement
        {
            get => "SELECT ID_Cliente, Nombre, Correo, Direccion, Telefono FROM [dbo].[Cliente]";
        }
        #endregion
        public void Delete(int id)
        {
            SqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@ID_Cliente",id)
            });
        }

        public IEnumerable<Cliente> GetAll(string filterExpression)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return ClienteAdapter.Current.Adapt(values);
                }
            }
        }

        public Cliente GetOne(int id)
        {
            try
            {


                using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                          new SqlParameter[] { new SqlParameter("@ID_Cliente", id) }))
                {
                    Object[] values = new Object[dr.FieldCount];

                    Cliente cliente = default;

                    while (dr.Read())
                    {
                        dr.GetValues(values);
                        cliente = ClienteAdapter.Current.Adapt(values);
                    }

                    return cliente;
                }
            }
            catch
            {
                //Services.Exceptions.Service.Handle(new DALException(ex));
                return null;
            }
        }

        public void Insert(Cliente obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
              {
                new SqlParameter("@Nombre", obj.Nombre),
                new SqlParameter("@Correo", obj.Correo),
                new SqlParameter("@Direccion", obj.Direccion),
                new SqlParameter("@Telefono",obj.Telefono),
               
              });
        }

        public void Update(Cliente obj)
        {
            SqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Nombre",obj.Nombre),
                new SqlParameter("@Correo", obj.Correo),
                new SqlParameter("@Direccion", obj.Direccion),
                new SqlParameter("@Telefono",obj.Telefono),
            });
        }
    }
}
