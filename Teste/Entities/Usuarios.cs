using System.ComponentModel.DataAnnotations;

namespace Teste.Entities
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Telefone { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Senha { get; set; }
        [Required]
        public byte[] Imagem { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        
        public List<Enderecos> Enderecos { get; set; } = new();
        public List<Contatos> Contatos { get; set; } = new();
    }
}
