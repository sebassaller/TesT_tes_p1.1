using Entrenamiento_netcore_cliente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace Entrenamiento_netcore_cliente.Datos
{
    public class AplicacionDB : DB_Conexion
    {

        public string? Insert_new_customer(M_Clientes_request m_Clientes)
        {
            string? unicode = "";
            try
            {
                abrir();
                SqlCommand cmd = new SqlCommand("Insertar_cliente", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 1);
                cmd.Parameters.AddWithValue("@id", Guid.Parse(m_Clientes.id));
                cmd.Parameters.AddWithValue("@Nombre", m_Clientes.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", m_Clientes.Apellido);
                cmd.Parameters.AddWithValue("@Email", m_Clientes.Email);
                cmd.Parameters.AddWithValue("@Domicilio", m_Clientes.Domicilio);
                cmd.Parameters.AddWithValue("@Password", m_Clientes.Password);
                cmd.Parameters.AddWithValue("@ciudad", m_Clientes.Ciudad);
                cmd.Parameters.AddWithValue("@Idciudad", Guid.Parse(m_Clientes.idCiudad));
                unicode = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cerrar();
            }
            return unicode;
        }
        public string? Delete_customer(M_Unicod_request m_Unicod)
        {
            string? unicode = "";
            try
            {
                abrir();
                SqlCommand cmd = new SqlCommand("Insertar_cliente", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 2);
                cmd.Parameters.AddWithValue("@id", Guid.Parse(m_Unicod.Id));
                unicode = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cerrar();
            }
            return unicode;
        }
        public M_Clientes_response update_client(M_Clientes_request m_Clientes)
        {
            DataTable dataTable = new DataTable();
            M_Clientes_response m_Clientes1 = new M_Clientes_response();
            try
            {
                abrir();
                SqlCommand cmd = new SqlCommand("Insertar_cliente", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 3);
                cmd.Parameters.AddWithValue("@id", Guid.Parse(m_Clientes.id));
                cmd.Parameters.AddWithValue("@Nombre", m_Clientes.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", m_Clientes.Apellido);
                cmd.Parameters.AddWithValue("@Email", m_Clientes.Email);
                cmd.Parameters.AddWithValue("@Password", m_Clientes.Password);
                cmd.Parameters.AddWithValue("@Domicilio", m_Clientes.Domicilio);
                cmd.Parameters.AddWithValue("Idciudad", Guid.Parse(m_Clientes.idCiudad));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                m_Clientes1 = rellenar(dataTable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cerrar();
            }
            return m_Clientes1;
        }
        private M_Clientes_response rellenar(DataTable data)
        {
            M_Clientes_response m_Clientes = new M_Clientes_response();
            foreach (DataRow row in data.Rows)
            {
                m_Clientes.id = row["id"].ToString();
                m_Clientes.Nombre = row["Nombre"].ToString();
                m_Clientes.Apellido = row["Apellido"].ToString();
                m_Clientes.Email = row["Email"].ToString();
                m_Clientes.Domicilio = row["Domicilio"].ToString();
                m_Clientes.Ciudad = row["ciudad"].ToString();
            }
            return m_Clientes;
        }
        public dynamic search_ciudad(M_ciudad_request m_Ciudad_Request)
        {
            dynamic? codigo = null;

            try
            {
                abrir();
                SqlCommand cmd = new SqlCommand("SP_ciudad", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 2);
                cmd.Parameters.AddWithValue("@Nombre", m_Ciudad_Request.Nombre);
                codigo = cmd.ExecuteScalar();
                if (codigo == null)
                {
                    codigo = insert_ciudad(m_Ciudad_Request);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cerrar();
            }
            return codigo;
        }
        private dynamic insert_ciudad(M_ciudad_request m_Ciudad_Request)
        {
            dynamic? codigo_ciiudad = Guid.NewGuid();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ciudad", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 1);
                cmd.Parameters.AddWithValue("@id", codigo_ciiudad);
                cmd.Parameters.AddWithValue("@Nombre", m_Ciudad_Request.Nombre);
                codigo_ciiudad = cmd.ExecuteScalar();
                return codigo_ciiudad;

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


        public List<M_Clientes_response> List_client()
        {

           
            List<M_Clientes_response> lista = new List<M_Clientes_response>();
   
            try
            {
                abrir();
                SqlCommand cmd = new SqlCommand("Insertar_cliente", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 4);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows) {
                    lista.Add(new M_Clientes_response() {
                        id = row["id"].ToString(),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Email = row["email"].ToString(),
                        Domicilio = row["Domicilio"].ToString(),
                        Ciudad = row["Ciudad"].ToString()
                    }) ;
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cerrar();
            }
            return lista;

        }
 




    }
}
