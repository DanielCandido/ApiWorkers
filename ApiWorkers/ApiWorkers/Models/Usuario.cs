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
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Senha { get; set; }

        public List<Usuario> ListarUsuarios()
        {

            var caminhoDB = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoDB);

            var listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

            return listaUsuarios;
        }

        public bool ReescreverArquivo(List<Usuario> listaUsuarios)
        {
            var caminhoDB = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaUsuarios, Formatting.Indented);
            File.WriteAllText(caminhoDB, json);

            return true;

        }

        public Usuario Inserir(Usuario Usuario)
        {
            var listaUsuario = this.ListarUsuarios();

            var maxId = listaUsuario.Max(p => p.Id);
            Usuario.Id = maxId + 1;
            listaUsuario.Add(Usuario);

            ReescreverArquivo(listaUsuario);

            return Usuario;
        }

        public Usuario Atualizar(int Id, Usuario Usuario)
        {
            var listaUsuario = this.ListarUsuarios();

            var itemIndex = listaUsuario.FindIndex(p => p.Id == Usuario.Id);
            if (itemIndex >= 0)
            {
                Usuario.Id = Id;
                listaUsuario[itemIndex] = Usuario;
            }
            else
            {
                return null;
            }

            ReescreverArquivo(listaUsuario);
            return Usuario;
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