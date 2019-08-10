using ApiWorkers.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiWorkers.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        [HttpGet]
        [Route("ListarCategorias")]
        public IHttpActionResult ListarCategorias()
        {
            try
            {
                Categoria categorias = new Categoria();
                return Ok(categorias.ListarCategorias());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Categoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
        }
    }
}
