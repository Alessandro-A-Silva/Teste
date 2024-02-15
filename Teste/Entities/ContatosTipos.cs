using System.ComponentModel.DataAnnotations;

namespace Teste.Entities
{
    public class ContatosTipos
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Contatos> Contatos { get; set; }
    }
}
