using System.Data.SqlClient;

namespace Entrenamiento_netcore_cliente.Datos
{
    public class DB_Conexion
    {

        public static string cadenaConexion = "Data Source=DESKTOP-39KK0F4;Initial Catalog=ejercicios_cliente;Integrated Security=True;";
   

        protected SqlConnection sqlConnection;
        protected void abrir()
        {
            try
            {
                sqlConnection = new SqlConnection(cadenaConexion);  
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected void cerrar()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }




    }
}
