using System.ComponentModel.DataAnnotations;

namespace Teste.Request
{
    public class PostUsuarioRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Telefone { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Senha { get; set; }
        [Required]
        public IFormFile Imagem { get; set; }
    }
}
