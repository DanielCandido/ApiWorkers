using System.ComponentModel.DataAnnotations;

namespace Workers.Domain
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo tem no minímo 3 caracteres e no maximo 50", MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage ="O campo Sobrenome é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo tem no minímo 3 caracteres e no maximo 50", MinimumLength = 3)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        [StringLength(11, ErrorMessage = "Campo deve conter 11 caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo Rg é obrigatório")]
        [StringLength(11, ErrorMessage = "Campo tem no minímo 7 caracteres e no maximo 11", MinimumLength = 7)]
        public string Rg { get; set; }
        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo Celular é obrigatório")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo tem no minímo 15 caracteres e no maximo 50", MinimumLength = 15)]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O campo Número é obrigatório")]
        public int NumeroCasa { get; set; }
        [Required(ErrorMessage = "O campo Complemento é obrigatório")]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo Uf é obrigatório")]
        public string Uf { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}