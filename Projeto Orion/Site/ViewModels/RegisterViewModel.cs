using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrionTM_Web.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [Display(Name = "Email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [Display(Name = "Telefone")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "É administrador")]
        [Display(Name = "IsAdm")]
        public bool IsAdm { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repita a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação Senha")]
        [MaxLength(20)]
        public string PasswordConf { get; set; }

        public string ReturnUrl { get; set; }
    }
}
