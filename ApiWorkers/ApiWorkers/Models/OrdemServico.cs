using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWorkers.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public long NumeroOrdem { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Prestador Prestador { get; set; }
        public int PrestadorId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataFinalizacao { get; set; }
    }
}