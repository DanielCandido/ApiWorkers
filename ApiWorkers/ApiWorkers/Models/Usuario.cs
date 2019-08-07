using ApiWorkers.DAO.UsuarioDAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ApiWorkers.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Senha { get; set; }

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                var usuarioDB = new UsuarioDAO();
                return usuarioDB.ListarUsuariosDB();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar usuarios: Erro => {e.Message}");
            }
        }

        public bool ReescreverArquivo(List<Usuario> listaUsuarios)
        {
            var caminhoDB = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaUsuarios, Formatting.Indented);
            File.WriteAllText(caminhoDB, json);

            return true;

        }

        public void Inserir(Usuario Usuario)
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

        public void Atualizar(Usuario Usuario)
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

        public bool Deletar(int Id)
        {
            var listaUsuarios = this.ListarUsuarios();

            var itemIndex = listaUsuarios.FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                listaUsuarios.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            ReescreverArquivo(listaUsuarios);
            return true;
        }
    }
}