﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWorkers.Controllers
{
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
