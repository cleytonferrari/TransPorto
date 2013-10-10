using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Agenda:Entidade
    {
        public Veiculo Veiculo { get; set; }
        public Motorista Motorista { get; set; }
        public List<Passageiro> Passageiro { get; set; }
        public DateTime DataAgendada { get; set; }
        public string OrigemDestino { get; set; }
    }
}
