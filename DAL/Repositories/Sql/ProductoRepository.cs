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
    internal class ProductoRepository : IGenericRepository<Producto>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Producto] (Nombre, Descripcion, Precio_Mayorista, Precio_Minorista, ID_TipodeProducto) VALUES (@Nombre, @Descripcion, @Precio_Mayorista, @Precio_Minorista, @ID_TipodeProducto)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Producto] SET (Nombre = @Nombre, Descripcion = @Descripcion, Precio_Mayorista = @Precio_Mayorista, Precio_Minorista = @Precio_Minorista, ID_TipodeProdcuto = @ID_TipodeProducto) WHERE ID_Producto = @ID_Producto";
        }
        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Producto] WHERE ID_Producto = @ID_Producto";
        }
        private string SelectOneStatement
        {
            get => "SELECT ID_Producto, Nombre, Descripcion, Precio_Mayorista, Precio_Minorista, ID_TipodeProducto FROM [dbo].[Producto] WHERE ID_Producto = @ID_Producto";
        }
        private string SelectAllStatement
        {
            get => "SELECT ID_Producto, Nombre, Descripcion, Precio_Mayorista, Precio_Minorista, ID_Tipodeproducto FROM [dbo].[Producto]";
        }
        #endregion
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetAll(string filterExpression)
        {
            string sqlStatement = filterExpression ?? SelectAllStatement;

            sqlStatement = (sqlStatement == filterExpression) ? SelectAllStatement + " where " + filterExpression : sqlStatement;

            using (var dr = SqlHelper.ExecuteReader(sqlStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return ProductoAdapter.Current.Adapt(values);
                }
            }
        }

        public Producto GetOne(int id)
        {
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                       new SqlParameter[] { new SqlParameter("@ID_Producto", id) }))
            {
                Object[] values = new Object[dr.FieldCount];

                Producto producto = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    producto = ProductoAdapter.Current.Adapt(values);
                }

                return producto;
            }
        }

        public void Insert(Producto obj)
        {
            SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter ("@Nombre", obj.Nombre),
                new SqlParameter ("@Descripcion", obj.Descripcion),
                new SqlParameter ("@Precio_Mayorista",obj.Precio_Mayorista),
                new SqlParameter ("@Precio_Minorista",obj.Precio_Minorista),
                new SqlParameter ("@ID_TipodeProducto", obj.ID_TipodeProducto)
            });
        }

        public void Update(Producto obj)
        {
            throw new NotImplementedException();
        }
    }
}
