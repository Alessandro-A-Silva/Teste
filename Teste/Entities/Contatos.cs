using System.ComponentModel.DataAnnotations;

namespace Teste.Entities
{
    public class Contatos
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Contato { get; set; }
        public ContatosTipos ContatoTipo { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
