using System.ComponentModel.DataAnnotations;

namespace WebApplicationIdentity.ViewModels
{
    public class ViewModelAlterarSenha
    {
        
        
        [Required(ErrorMessage = "Informe sua senha atual")]
        [Display(Name = "Senha atual")]
        [DataType(DataType.Password)]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
        [Display(Name = "Confirme a senha")]
        public string ConfirmarSenha { get; set; }

    }
}