namespace Workers.Domain
{
    public class SubcategoriaDTO
    {
        public int Id { get; set; }
        public string NomeSubcategoria { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
