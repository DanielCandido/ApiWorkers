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
    [RoutePrefix("api/Prestador")]
    public class PrestadorController : ApiController
    {
        [HttpGet]
        [Route("ListarPrestadores")]
        public IHttpActionResult ListarUsuarios()
        {
            try
            {
                Prestador prestador = new Prestador();
                return Ok(prestador.ListarPrestadores());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Prestador
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prestador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prestador/5
        public void Delete(int id)
        {
        }
    }
}
