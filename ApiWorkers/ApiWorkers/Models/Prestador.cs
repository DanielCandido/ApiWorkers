using System;
using System.Collections.Generic;
using Workers.Domain;
using Workers.Repository;

namespace ApiWorkers.Models
{
    public class Prestador
    {

        public List<PrestadorDTO> ListarPrestadores(int? id = null)
        {
            try
            {
                var prestadorDB = new PrestadorDAO();
                return prestadorDB.ListarPrestadorDb(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao listar Prestadores: Erro => {ex.Message}");
            }
        }
    }
}