using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Agenda:Entidade
    {
        public List<string> Disponive { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
