using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWorkers
{
    public class BaseUsuarios
    {
        public static IEnumerable<Usuarios> Usuarios()
        {
            return new List<Usuarios>
            {
                new Usuarios {Nome = "Admin", Senha = "grove170596",
                    Funcoes = new string[] { Funcao.Administrador } },
                new Usuarios {Nome = "Seo", Senha = "grove170596",
                    Funcoes = new string[] { Funcao.Administrador, Funcao.Usuario } },
                new Usuarios {Nome = "Dev", Senha="grove170596",
                    Funcoes =  new string[] { Funcao.Usuario } },
            };
        }
    }

    public class Usuarios
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public string[] Funcoes { get; set; }
    }

    public class Funcao
    {
        public const string Usuario = "Usuario";
        public const string Prestador = "Prestador";
        public const string Administrador = "Administrador";
    }
}