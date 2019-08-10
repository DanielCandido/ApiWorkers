using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workers.Domain;
using Workers.Repository;

namespace ApiWorkers.Models
{
    public class OrdemServico
    {
        public List<OrdemServicoDTO> ListarOrdens(int? id = null)
        {
            try
            {
                var ordemDB = new OrdemServicoDAO();
                return ordemDB.ListarOrdemDB(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar Ordems de Serviço: Erro => {e.Message}");
            }
        }
    }
}