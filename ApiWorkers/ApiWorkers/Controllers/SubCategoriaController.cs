using ApiWorkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiWorkers.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Subcategoria")]
    public class SubCategoriaController : ApiController
    {
        [HttpGet]
        [Route("ListarSubcategoria")]
        public IHttpActionResult ListarSubcategoria()
        {
            try
            {
                Subcategoria subcategorias = new Subcategoria();
                return Ok("");
            } catch
            {
                return NotFound();
            }
        }

        // GET: api/SubCategoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SubCategoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SubCategoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SubCategoria/5
        public void Delete(int id)
        {
        }
    }
}
