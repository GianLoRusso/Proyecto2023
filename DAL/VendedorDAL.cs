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
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Vendedor VALUES (@VendorName)");

            SQLComando.Parameters.Add("@VendorName", SqlDbType.VarChar).Value= oVendedor.Nombre;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);

            //return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO Vendedor(Nombre, Contraseña)VALUES('"+oVendedor.Nombre+ oVendedor.Contraseña+"')");

        }
        public int Eliminar(Vendedor oVendedor)
        {
            conexion.ejecutarComandoSinRetornoDatos("DELETE FROM Vendedor WHERE ID="+ oVendedor.ID);

            return 1;
        }
        public int Modificar(Vendedor oVendedor)
        {
            conexion.ejecutarComandoSinRetornoDatos("UPDATE Vendedor "+ 
                "SET Nombre='"+oVendedor.Nombre +"'"+
                "WHERE ID=" + oVendedor.ID);

            return 1;
        }
        public DataSet MostrarVendedores()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Vendedor");

            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
