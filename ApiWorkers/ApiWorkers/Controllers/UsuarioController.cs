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
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpGet]
        [Route("ListarUsuarios")]
        public IHttpActionResult ListarUsuarios()
        {
            try
            {
                Usuario usuarios = new Usuario();
                return Ok(usuarios.ListarUsuarios());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // GET: api/Usuario/5
        [HttpGet]
        [Route("RecuperarUsuario/{id:int}")]
        public Usuario RecuperarPorId(int id)
        {
            Usuario usuario = new Usuario();
            return usuario.ListarUsuarios(id).FirstOrDefault();
        }

        [HttpGet]
        [Route(@"RecuperarUsuarioCpf/{cpf}")]
        public Usuario RecuperarPorCpf(string cpf)
        {
            Usuario usuario = new Usuario();
            return usuario.ListarUsuarios().Where(x => x.Cpf == cpf).FirstOrDefault();
        }

        [HttpGet]
        [Route("RecuperarUsuarioRegiao/{regiao}")]
        public IHttpActionResult RecuperarPorRegiao(string regiao)
        {
            try
            {
                Usuario usuario = new Usuario();
                if(regiao == "Sul")
                {
                    IEnumerable<Usuario> usuarios = usuario.ListarUsuarios().
                        Where(x => x.Uf == "PR" || x.Uf == "SC" || x.Uf == "RS");

                    if (!usuarios.Any())
                        return NotFound();

                    return Ok(usuarios);
                }
                else if (regiao == "Suldeste")
                {
                    IEnumerable<Usuario> usuarios = usuario.ListarUsuarios().
                       Where(x => x.Uf == "SP" || x.Uf == "RJ" || x.Uf == "ES" || x.Uf == "MG");

                    if (!usuarios.Any())
                        return NotFound();

                    return Ok(usuarios);
                }
                else if (regiao == "CentroOeste")
                {
                    IEnumerable<Usuario> usuarios = usuario.ListarUsuarios().
                       Where(x => x.Uf == "MT" || x.Uf == "MS" || x.Uf == "GO");

                    if (!usuarios.Any())
                        return NotFound();

                    return Ok(usuarios);
                }
                else if(regiao == "Nordeste")
                {
                    IEnumerable<Usuario> usuarios = usuario.ListarUsuarios().
                       Where(x => x.Uf == "MA" || x.Uf == "PI" || x.Uf == "CE" || x.Uf == "RN" || x.Uf == "PE" || x.Uf == "PB" || x.Uf == "SE" || x.Uf == "AL" || x.Uf == "BA");

                    if (!usuarios.Any())
                        return NotFound();

                    return Ok(usuarios);
                }
                else if(regiao == "Norte")
                {

                    IEnumerable<Usuario> usuarios = usuario.ListarUsuarios().
                       Where(x => x.Uf == "AM" || x.Uf == "RR" || x.Uf == "AP" || x.Uf == "PA" || x.Uf == "TO" || x.Uf == "RO" || x.Uf == "AC");

                    if (!usuarios.Any())
                        return NotFound();

                    return Ok(usuarios);
                }
                else
                {
                    return NotFound();
                }

                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public List<Usuario> Post(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            Verifica(usuario);

            return _usuario.ListarUsuarios();

        }

        [HttpPost]
        [Route("InserirUsuario")]
        public bool Verifica(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            IEnumerable<Usuario> usuarios = _usuario.ListarUsuarios().Where(x => x.Cpf == usuario.Cpf || x.Rg == usuario.Rg || x.Email == usuario.Email);

            if (!usuarios.Any())
            {
                _usuario.Inserir(usuario);
                return true;
            }
            else
            {
                return false;  
            }
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public Usuario Put(int id, [FromBody]Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            usuario.Id = id;

            _usuario.Atualizar(usuario);

            return _usuario.ListarUsuarios().FirstOrDefault(usu => usu.Id == id);
        }

        // DELETE: api/Usuario/5
        [HttpDelete]
        public void Delete(int id)
        {
            Usuario _usuario = new Usuario();

            _usuario.Deletar(id);
        }
    }
}