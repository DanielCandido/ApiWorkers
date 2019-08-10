using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Workers.Domain;

namespace Workers.Repository
{
    public class OrdemServicoDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public OrdemServicoDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<OrdemServicoDTO> ListarOrdemDB(int? id)
        {
            try
            {
                var listarOrdem = new List<OrdemServicoDTO>();

                IDbCommand selectQuery = conexao.CreateCommand();

                if (id == null)
                {
                    selectQuery.CommandText = "select * from OrdemServico";
                }
                else
                {
                    selectQuery.CommandText = $"Select * from OrdemServico where Id = {id}";
                }

                IDataReader resultado = selectQuery.ExecuteReader();
                while (resultado.Read())
                {
                    var ord = new OrdemServicoDTO
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        NumeroOrdem = Convert.ToInt32(resultado["NumeroOrdem"]),
                        PrestadorId = Convert.ToInt32(resultado["PrestadorId"]),
                        DataFinalizacao = Convert.ToDateTime(resultado["DataFinalizacao"]),
                        UsuarioId = Convert.ToInt32(resultado["UsuarioId"]),
                        DataPedido = Convert.ToDateTime(resultado["DataPedido"]),
                    };
                    listarOrdem.Add(ord);

                }

                return listarOrdem;
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