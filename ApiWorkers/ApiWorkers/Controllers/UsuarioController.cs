using ApiWorkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyJob.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            Usuario usuarios = new Usuario();
            return usuarios.ListarUsuarios();
        }

        // GET: api/Usuario/5
        public Usuario Get(int id)
        {
            Usuario usuario = new Usuario();
            return usuario.ListarUsuarios().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Usuario
        public List<Usuario> Post(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            _usuario.Inserir(usuario);

            return _usuario.ListarUsuarios();

        }

        // PUT: api/Usuario/5
        public Usuario Put(int id, [FromBody]Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            return _usuario.Atualizar(id, usuario);
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            Usuario _usuario = new Usuario();

            _usuario.Deletar(id);
        }
    }
}