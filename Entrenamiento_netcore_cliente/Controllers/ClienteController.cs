using Entrenamiento_netcore_cliente.Datos;
using Entrenamiento_netcore_cliente.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Entrenamiento_netcore_cliente.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        AplicacionDB dB = new AplicacionDB();
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista(string? nombre)
        {

            List<M_Clientes_response> lista = dB.List_client();
            if (nombre != null) {

                lista = lista.FindAll(l => l.Nombre == nombre);
            
            }
            return  Ok(lista);
        }



        //[HttpPost]
        //[Route("Login")]
        //public dynamic Login(string User, string Password)
        //{
        //    return new M_Clientes_request()
        //    {
        //        id = "1",
        //        Nombre = User,
        //        Apellido = "Saller",
        //        Domicilio = "nose",
        //        Email = "nose",
        //        Password = Password,
        //        idCiudad = "2",
        //        Habilitado = 1
        //    };
        //}



        [HttpPost]
        [Route("new_client")]
        public IActionResult new_client(string Nombre, string Apellido, string Email, string Domicilio, string password, string ciudad)
        {
            M_Clientes_request m_Clientes = new M_Clientes_request()
            {
                id = Guid.NewGuid().ToString(),
                Nombre = Nombre,
                Apellido = Apellido,
                Email = Email,
                Domicilio = Domicilio,
                Password = password,
                Ciudad = ciudad
            };
            m_Clientes.idCiudad =Convert.ToString(dB.search_ciudad(new M_ciudad_request() { Nombre = ciudad }));
            var resul = dB.Insert_new_customer(m_Clientes);
            return Ok("su codigo de identificacion es:" + resul);
        }


        [HttpPost]
        [Route("Delete_client")]
        public IActionResult Delect_client(string id)
        {
            var resul = dB.Delete_customer( new M_Unicod_request() { Id = id });
            return Ok("su codigo de identificacion es:");
        }



        [HttpPost]
        [Route("update_client")]
        public IActionResult update_client(string Nombre, string Apellido, string Email, string Domicilio, string password, string id, string ciudad)
        {
 
            M_Clientes_request m_Clientes = new M_Clientes_request()
            {
                id = id,
                Nombre = Nombre,
                Apellido = Apellido,
                Email = Email,
                Domicilio = Domicilio,
                Password = password,
            };
            m_Clientes.idCiudad = Convert.ToString(dB.search_ciudad(new M_ciudad_request() { Nombre = ciudad }));
            M_Clientes_response resul = dB.update_client(m_Clientes);
            return Ok(resul);
        }
    }
}
