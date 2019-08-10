using System;
using System.Collections.Generic;
using Workers.Domain;
using Workers.Repository;

namespace ApiWorkers.Models
{
    public class Usuario
    {
        public List<UsuarioDTO> ListarUsuarios(int? id = null)
        {
            try
            {
                var usuarioDB = new UsuarioDAO();
                return usuarioDB.ListarUsuariosDB(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar usuarios: Erro => {e.Message}");
            }
        }

        /*public bool ReescreverArquivo(List<Usuario> listaUsuarios)
        {
            var caminhoDB = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaUsuarios, Formatting.Indented);
            File.WriteAllText(caminhoDB, json);

            return true;

        }*/

        public void Inserir(UsuarioDTO Usuario)
        {
            try
            {
                var usuarioDB = new UsuarioDAO();
                usuarioDB.InserirUsuarioDB(Usuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Inserir usuario: Erro => {e.Message}");
            }
        }

        public void Atualizar(UsuarioDTO Usuario)
        {
            try
            {
                var usuarioDB = new UsuarioDAO();
                usuarioDB.AtualizarUsuarioDB(Usuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Atualizar usuario: Erro => {e.Message}");
            }
        }

        public void Deletar(int Id)
        {
            try
            {
                var usuarioDB = new UsuarioDAO();
                usuarioDB.DeletarUsuarioDB(Id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Deletar usuario: Erro => {e.Message}");
            }
        }
    }
}