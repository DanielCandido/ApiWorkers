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
    [RoutePrefix("api/OrdemServico")]
    public class OrdemServicoController : ApiController
    {
        [HttpGet]
        [Route("ListarOrdens")]
        public IHttpActionResult ListarOdens()
        {
            try
            {
                OrdemServico ordem = new OrdemServico();
                return Ok(ordem.ListarOrdens());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET: api/OrdemServico/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrdemServico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrdemServico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrdemServico/5
        public void Delete(int id)
        {
        }
    }
}
