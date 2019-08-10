using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workers.Domain;
using Workers.Repository;

namespace ApiWorkers.Models
{
    public class Categoria
    {
        public List<CategoriaDTO> ListarCategorias(int ? id = null)
        {
            try
            {
                var categoriaDB = new CategoriaDAO();
                return categoriaDB.ListarCategoriaDb(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Categorias: erro => {ex.Message}");
            }
        }
    }
}