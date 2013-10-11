using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario: Entidade
    {
        [Required(ErrorMessage = "O campo noeme deve ser informado!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo Login deve ser informado!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Uma senha deve ser informado!")]
        public string Senha { get; set; }
    }
}
