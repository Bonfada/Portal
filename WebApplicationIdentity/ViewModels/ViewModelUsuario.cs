using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationIdentity.ViewModels
{
    public class ViewModelUsuario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Informe seu nome.")]
        [MaxLength(50,ErrorMessage ="O nome deve ter no máximo 50 carácteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu E-mail.")]
        [MaxLength(50, ErrorMessage = "O E-mail deve ter no máximo 50 carácteres")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(15,ErrorMessage = "O login deve ter no máximo 15 carácteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="A senha deve ter no mínimo 6 caracteres")]
        [MaxLength(50, ErrorMessage = "A senha deve ter no máximo 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [Compare(nameof(Senha),ErrorMessage ="As senhas devem ser iguais")]
        [Display(Name ="Confirme a senha")]
        public string ConfirmarSenha { get; set; }
    }
}