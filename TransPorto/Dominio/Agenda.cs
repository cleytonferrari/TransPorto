using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Dominio
{
    public class Agenda:Entidade
    {
        [Required(ErrorMessage = "Qual veiculo será agendado?")]
        public Veiculo Veiculo { get; set; }
        [Required(ErrorMessage = "O Campo deve ser informado!")]
        public Motorista Motorista { get; set; }
        public Passageiro Passageiro { get; set; }
        [Required(ErrorMessage = "O dia deste agendamento deve ser informado!")]
        public string DataAgendada { get; set; }
        [Display(Name = "Origem e Destino")]
        [Required(ErrorMessage = "O campo deve ser informado!")]
        public string OrigemDestino { get; set; }
        [Required(ErrorMessage = "O campo deve ser informado!")]
        public string Horario { get; set; }
        }
}
