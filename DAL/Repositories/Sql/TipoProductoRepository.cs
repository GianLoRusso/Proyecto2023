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
    internal class TipoProductoRepository : IGenericRepository<TipoProducto>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[TipoProducto] (NombreCategoria) VALUES (@NombreCategoria)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[TipoProducto] SET (NombreCategoria= @NombreCategoria) WHERE ID_TipodeProducto = @ID_TipodeProducto";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[TipoProducto] WHERE ID_TipodeProducto = @ID_TipodeProducto";
        }

        private string SelectOneStatement
        {
            get => "SELECT ID_TipodeProducto, NombreCategoria FROM [dbo].[TipoProducto] WHERE ID_TipodeProducto = @ID_TipodeProducto";
        }

        private string SelectAllStatement
        {
            get => "SELECT ID_TipodeProducto, NombreCategoria FROM [dbo].[ID_TipodeProducto]";
        }


        #endregion

        public void Delete(int id)
        {
            SqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, new SqlParameter[]
           {
                new SqlParameter("@ID_TipodeProducto",id),
           });
        }

        public IEnumerable<TipoProducto> GetAll(string filterExpression)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return TipoProductoAdapter.Current.Adapt(values);
                }
            }
        }

        public TipoProducto GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_TipodeProducto", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                TipoProducto tipodeproducto = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    tipodeproducto = TipoProductoAdapter.Current.Adapt(values);
                }

                return tipodeproducto;
            }
        }

        public void Insert(TipoProducto obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@NombreCategoria", obj.NombreCategoria),
            });
        }

        public void Update(TipoProducto obj)
        {
            SqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, new SqlParameter[]
           {
                new SqlParameter("@NombreCategoria", obj.NombreCategoria),
           });
        }
    }
}
