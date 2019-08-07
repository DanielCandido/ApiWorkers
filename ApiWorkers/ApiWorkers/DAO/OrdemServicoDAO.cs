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
    public class OrdemServicoDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDB"].ConnectionString;
        private IDbConnection conexao;

        public OrdemServicoDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<OrdemServico> ListarOrdemDB(int? id)
        {
            var listarOrdem = new List<OrdemServico>();

            IDbCommand selectQuery = conexao.CreateCommand();

            if(id == null)
            {
                selectQuery.CommandText = "select * from OrdemServico";
            } else
            {
                selectQuery.CommandText = $"Select * from OrdemServico where Id = {id}";
            }

            IDataReader resultado = selectQuery.ExecuteReader();
            while (resultado.Read())
            {
                var ord = new OrdemServico();

                ord.Id = Convert.ToInt32(resultado["Id"]);
                ord.NumeroOrdem = Convert.ToInt32(resultado["NumeroOrdem"]);
                ord.PrestadorId = Convert.ToInt32(resultado["PrestadorId"]);
                ord.UsuarioId = Convert.ToInt32(resultado["UsuarioId"]);
                ord.DataPedido = Convert.ToDateTime(resultado["DataPedido"]);
                ord.DataFinalizacao = Convert.ToDateTime(resultado["DataFinalizacao"]);

                listarOrdem.Add(ord);

            }
            conexao.Close();

            return listarOrdem;
        }
    }
}