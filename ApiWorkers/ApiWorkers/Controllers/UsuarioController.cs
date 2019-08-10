using ApiWorkers;
using ApiWorkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Workers.Domain;

namespace MyJob.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpGet]
        [Route("ListarUsuarios")]
        [Authorize(Roles = Funcao.Administrador)]
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
        public IHttpActionResult RecuperarPorId(int id)
        {
            try
            {
                Usuario usuario = new Usuario();
                return Ok(usuario.ListarUsuarios(id).FirstOrDefault());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpGet]
        [Route(@"RecuperarUsuarioCpf/{cpf}")]
        public IHttpActionResult RecuperarPorCpf(string cpf)
        {
            try
            {
                Usuario usuario = new Usuario();
                IEnumerable<UsuarioDTO> usuarios = usuario.ListarUsuarios().Where(x => x.Cpf == cpf);

            //    if (!usuarios.Any())
            //        return NotFound();

                return Ok(usuarios);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        /*[HttpGet]
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
        */

        // POST: api/Usuario
        [HttpPost]
        [Route("InserirUsuario")]
        public IHttpActionResult Post(UsuarioDTO usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Usuario _usuario = new Usuario();

                IEnumerable<UsuarioDTO> usuarios = _usuario.ListarUsuarios().Where(x => x.Cpf == usuario.Cpf || x.Rg == usuario.Rg || x.Email == usuario.Email);

                if (!usuarios.Any())
                {
                    _usuario.Inserir(usuario);
                }
                else
                {
                    return InternalServerError();
                }

                return Ok(_usuario.ListarUsuarios());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            

        }

        // PUT: api/Usuario/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]UsuarioDTO usuario)
        {
            try
            {
                Usuario _usuario = new Usuario();

                usuario.Id = id;

                _usuario.Atualizar(usuario);

                return Ok(_usuario.ListarUsuarios(id).FirstOrDefault());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        // DELETE: api/Usuario/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Usuario _usuario = new Usuario();

                _usuario.Deletar(id);

                return Ok("Deletado Com Sucesso");
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }
    }
}