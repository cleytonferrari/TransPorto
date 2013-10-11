using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Agenda:Entidade
    {
        public Veiculo Veiculo { get; set; }
        public Motorista Motorista { get; set; }
        public Passageiro Passageiro { get; set; }
        public DateTime DataAgendada { get; set; }
        
        [Display(Name = "Origem e Destino")]
        public string OrigemDestino { get; set; }
        public string Buscar { get; set; }
        
        [Display(Name = "Companhia Aerea")]
        public CompanhiasAereas CompanhiasAereas { get; set; }

        public double ValorPassage { get; set; }

    }
}
