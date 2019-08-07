using ApiWorkers.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiWorkers.DAO
{
    public class CategoriaDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDB"].ConnectionString;
        private IDbConnection conexao;


        public CategoriaDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<Categoria> ListarCategoriaDb(int? id)
        {
            var listarCategorias = new List<Categoria>();

            IDbCommand selectQuery = conexao.CreateCommand();

            if(id == null)
            {
                selectQuery.CommandText = "Select * from Categorias";
            } else
            {
                selectQuery.CommandText = $"Select * from Categorias Where Id = {id}";
            }

            IDataReader resultado = selectQuery.ExecuteReader();
            while (resultado.Read())
            {
                var cat = new Categoria();

                cat.Id = Convert.ToInt32(resultado["Id"]);
                cat.NomeCategoria = Convert.ToString(resultado["Nome"]);

                listarCategorias.Add(cat);
            }
            conexao.Close();

            return listarCategorias;
        }
    }
}