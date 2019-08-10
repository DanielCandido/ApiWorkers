using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Workers.Domain;

namespace Workers.Repository
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

        public List<CategoriaDTO> ListarCategoriaDb(int? id)
        {
            try
            {
                var listarCategorias = new List<CategoriaDTO>();

                IDbCommand selectQuery = conexao.CreateCommand();

                if (id == null)
                {
                    selectQuery.CommandText = "Select * from Categorias";
                }
                else
                {
                    selectQuery.CommandText = $"Select * from Categorias Where Id = {id}";
                }

                IDataReader resultado = selectQuery.ExecuteReader();
                while (resultado.Read())
                {
                    var cat = new CategoriaDTO
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        NomeCategoria = Convert.ToString(resultado["Nome"]),
                    };

                    listarCategorias.Add(cat);
                }

                return listarCategorias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            
        }
    }
}