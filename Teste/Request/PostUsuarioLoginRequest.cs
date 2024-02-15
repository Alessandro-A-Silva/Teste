using System.ComponentModel.DataAnnotations;

namespace Teste.Request
{
    public class PostUsuarioLoginRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Senha { get; set; }
    }
}
