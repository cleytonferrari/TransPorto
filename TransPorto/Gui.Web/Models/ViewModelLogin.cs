using System.ComponentModel.DataAnnotations;
using Dominio;

namespace GUI.Web.Models
{
    public class ViewModelLogin
    {
        [Required(ErrorMessage = "O Login deve ser informado!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha deve ser informada!")]
        public string Senha { get; set; }
    }
}