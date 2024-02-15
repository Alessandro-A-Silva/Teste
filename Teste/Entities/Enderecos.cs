using System.ComponentModel.DataAnnotations;

namespace Teste.Entities
{
    public class Enderecos
    {
        [Key]
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }
        public Usuarios Usuario { get; set; }
        public Estados Estado { get; set; }
    }
}
