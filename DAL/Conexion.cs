using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAL
{
     public class Conexion
    {
        private string CadenaConexion = "Data Source=DESKTOP-N5I8Q7T; Initial Catalog=Proye23; Integrated Security = True";
        SqlConnection Connection;

        public SqlConnection EstablecerConexion()
        {
         this.Connection = new SqlConnection(this.CadenaConexion);
         return this.Connection;
        }
        
        public bool ejecutarComandoSinRetornoDatos(string StrComando)
        {
            try 
            {
                
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = StrComando;
                Comando.Connection = this.EstablecerConexion();
                Connection.Open();
                Comando.ExecuteNonQuery();
                Connection.Close();

                return true;
            }
            catch 
            {
                return false;
            }
        }
        //Sobrecarga
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {

                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                Connection.Open();
                Comando.ExecuteNonQuery();
                Connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //SELECT
        public DataSet EjecutarSentencia (SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try 
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Connection.Open();
                Adaptador.Fill(DS);
                Connection.Close();
                return DS;

            }
            catch 
            {
                return DS;
            }

        }
    }
}
