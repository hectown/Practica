using Practica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Practica.Controllers
{
    [RoutePrefix("api/Anuncios")]
    public class AnunciosController : ApiController
    {

        AnunciosDAOImpl _anunciosDAO = new AnunciosDAOImpl();



        [HttpGet]
        [Route("Items")]
        // GET: api/Anuncios
        public async Task<IHttpActionResult> Get()
        {
            // return new string[] { "value1", "value2" };

            var anuncios = await _anunciosDAO.GetAnunciosAsync();
            return Ok(anuncios);



        }



        [HttpGet]
        [Route("Categorias")]
        public async Task<IHttpActionResult> GetCategorias()
        {

            var cat = await _anunciosDAO.GetCategoriasAsync();
            return Ok(cat);

        }



        // GET: api/Anuncios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Anuncios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Anuncios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Anuncios/5
        public void Delete(int id)
        {
        }
    }
}
