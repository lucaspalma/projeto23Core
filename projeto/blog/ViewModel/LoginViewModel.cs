using System.ComponentModel.DataAnnotations;

namespace blog.ViewModel
{
    public class LoginViewModel
    {
        [Required] [Display(Name = "Usuário")]
        public string LoginName { get; set; }

        [Required] [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }   
    }
}