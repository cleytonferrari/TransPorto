using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Motorista:Entidade
    {
        [Required(ErrorMessage = "O campo deve ser informado!")]
        public string Nome { get; set; }
    }
}
