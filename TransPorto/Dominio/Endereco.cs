using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Endereco : Entidade
    {
        [Required(ErrorMessage = "A Rua deve ser informado!")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O Numero deve ser informado!")]
        public string Numero { get; set; }
        public string Cep { get; set; }
        [Required(ErrorMessage = "O Bairro deve ser informado!")]
        public string Bairro { get; set; }

        public Municipio Municipio { get; set; }
    }
}