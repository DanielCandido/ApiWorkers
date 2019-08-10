using System;

namespace Workers.Domain
{
    public class OrdemServicoDTO
    {
        public int Id { get; set; }
        public long NumeroOrdem { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int UsuarioId { get; set; }
        public PrestadorDTO Prestador { get; set; }
        public int PrestadorId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataFinalizacao { get; set; }
    }
}
