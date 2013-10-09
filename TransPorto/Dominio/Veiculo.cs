using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Veiculo:Entidade
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string QuantidadeDePassageiros { get; set; }
        public bool Estatus { get; set; }
    }
}
