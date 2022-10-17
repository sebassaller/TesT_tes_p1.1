using Entrenamiento_netcore_cliente.Datos;
using Entrenamiento_netcore_cliente.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entrenamiento_netcore_cliente.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {


        AplicacionDB dB = new AplicacionDB();
        [HttpPost]
        [Route("Login")]
        public dynamic Login(string? User, string? Password)
        {

            //este lo estaba haciendo pero no llege a terminarlo hoy

            List<M_Clientes_response> lista = dB.List_client();
            if (User == null || Password == null)
            {
                return Ok("Usuario o contraseña incorrecta");
            }
            else
            {
                return lista.FindAll(l => l.Nombre == User && l.Password == Password);

            }
        }
    }
}
