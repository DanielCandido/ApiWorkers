using ApiWorkers.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWorkers.Models
{
    public class Subcategoria
    {
        public int Id { get; set; }
        public string NomeSubcategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }

    /**public List<Subcategoria> ListarSubcategoria()
    {
        try
        {
            var subcategoriaDB = new SubcategoriaDAO();
            return usuarioDB.ListarUsuariosDB();
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao listar usuarios: Erro => {e.Message}");
        }
    }*/
}
