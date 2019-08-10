using System;
using System.Collections.Generic;
using Workers.Domain;
using Workers.Repository;

namespace ApiWorkers.Models
{
    public class Subcategoria
    {
        public List<SubcategoriaDTO> ListarSubcategoria(int? id = null)
        {
            try
            {
                var subcategoriaDB = new SubcategoriaDAO();
                return subcategoriaDB.ListarSubcategoriaDB(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar usuarios: Erro => {e.Message}");
            }
        }
    }

}
