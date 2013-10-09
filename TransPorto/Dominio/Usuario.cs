using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario: Entidade
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
