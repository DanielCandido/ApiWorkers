using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Workers.Domain;

namespace Workers.Repository
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

        public List<SubcategoriaDTO> ListarSubcategoriaDB(int ? id) 
        {
            try
            {
                var listarSubcategorias = new List<SubcategoriaDTO>();

                IDbCommand selectQuery = conexao.CreateCommand();
                selectQuery.CommandText = "select * from subcategorias";

                IDataReader resultado = selectQuery.ExecuteReader();
                while (resultado.Read())
                {
                    var subcat = new SubcategoriaDTO()
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        NomeSubcategoria = Convert.ToString(resultado["NomeSubcategoria"]),
                        CategoriaId = Convert.ToInt32(resultado["CategoriaId"]),
                    };

                    listarSubcategorias.Add(subcat);

                }
           
                return listarSubcategorias;
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