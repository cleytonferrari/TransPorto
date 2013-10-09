using System;

namespace Dominio
{
    class Agenda:Entidade
    {
        public Veiculo Veiculo { get; set; }
        public Motorista Motorista { get; set; }
        public DateTime DataAgendada { get; set; }
        public string Destino { get; set; }
    }
}
