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
    public class SubcategoriaDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public SubcategoriaDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<Subcategoria> ListarSubcategoriaDB()
        {
            var listarSubcategorias = new List<Subcategoria>();

            IDbCommand selectQuery = conexao.CreateCommand();
            selectQuery.CommandText = "select * from subcategorias";

            IDataReader resultado = selectQuery.ExecuteReader();
            while (resultado.Read())
            {
                var subcat = new Subcategoria();

                subcat.Id = Convert.ToInt32(resultado["Id"]);
                subcat.NomeSubcategoria = Convert.ToString(resultado["NomeSubcategoria"]);
                subcat.CategoriaId = Convert.ToInt32(resultado["CategoriaId"]);

                listarSubcategorias.Add(subcat);

            }

            conexao.Close();

            return listarSubcategorias;
        }
    }
}