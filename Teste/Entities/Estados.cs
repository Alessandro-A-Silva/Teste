using System.ComponentModel.DataAnnotations;

namespace Teste.Entities
{
    public class Estados
    {
        [Key]
        public int Id { get; set; }
        public int CodigoUf { get; set; }
        public string UnidadeDaFederacao { get; set; }
        public string Uf { get; set; }
        public List<Enderecos> Enderecos { get; set; }
    }
}
