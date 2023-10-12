using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Domain;

namespace DAL
{
    public class VendedorDAL
    {
        Conexion conexion;

        public VendedorDAL() 
        {
            conexion = new DAL.Conexion();
        }

        public bool Agregar(Vendedor oVendedor)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Vendedor VALUES (@Nombre)");

            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value= oVendedor.Nombre;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);

            //return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO Vendedor(Nombre, Contraseña)VALUES('"+oVendedor.Nombre+ oVendedor.Contraseña+"')");

        }
        public bool Eliminar(Vendedor oVendedor)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Vendedor WHERE ID=@ID ");

            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oVendedor.ID;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }
        public bool Modificar(Vendedor oVendedor)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Vendedor SET Nombre=@Nombre WHERE ID=@ID");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oVendedor.Nombre;
            SQLComando.Parameters.Add("@ID",SqlDbType.Int).Value = oVendedor.ID;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }
        public DataSet MostrarVendedores()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Vendedor");

            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
