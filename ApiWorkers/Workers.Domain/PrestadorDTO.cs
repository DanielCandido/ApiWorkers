namespace Workers.Domain
{
    public class PrestadorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public int CategoriaId { get; set; }
        public SubcategoriaDTO Subcategoria { get; set; }
        public int SubcategoriaId { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Senha { get; set; }
    }
}
