using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Practica.DTOs;
using Practica.Services;

namespace Practica.Controllers
{
    [RoutePrefix("api/Correo")]
    public class CorreoController : ApiController
    {
        EmailServices emailService = new EmailServices();
        // GET: api/Correo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Correo/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("Send")]

        public async Task<IHttpActionResult> SendAsync([FromBody] CorreoRequest correoRequest)
        // public async Task<IHttpActionResult> SendAsync()
        {
            var resultado = emailService.SendAsync(correoRequest.Correo, correoRequest.Nombre, "angello_dm@hotmail.com", "Miguel Gonzalez Nava",correoRequest.Asunto, correoRequest.Mensaje);
           // var resultado = emailService.SendAsync("hectown@gmail.com", "hector", "hectown@gmail.com", "miguel", "prueba", "texto de prueba");

            return Ok(resultado);

        }

        // PUT: api/Correo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Correo/5
        public void Delete(int id)
        {
        }
    }
}
