using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;

namespace Aplicacao
{
    public class AplicacaoMotorista:Aplicacao<Motorista>
    {
        private readonly IContexto<Motorista> _contexto; 
        public AplicacaoMotorista(IContexto<Motorista> repositorio) : base(repositorio)
        {
            _contexto = repositorio;
        }
    }
}
