using System.ComponentModel.DataAnnotations;

namespace WebApplicationIdentity.ViewModels
{
    public class ViewModelLogin
    {

        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(15,ErrorMessage = "O login deve ter no máximo 10 carácteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha.")]

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; }
    }
}