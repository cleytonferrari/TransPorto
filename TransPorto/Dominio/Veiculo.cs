using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Veiculo:Entidade
    {
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A placa do veiculo deve ser informado!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de passageiro suportado!")]
        [Display(Name = "Quantidade de Passageiro")]
        public string QuantidadeDePassageiros { get; set; }

        [Required(ErrorMessage = "O veiculo esta em condições operacionais?")]
        public bool Estatus { get; set; }

        [Required(ErrorMessage = "Quais os dias que o veiculo estara disponivel?")]
        public string Disponivel { get; set; }
    }
}
