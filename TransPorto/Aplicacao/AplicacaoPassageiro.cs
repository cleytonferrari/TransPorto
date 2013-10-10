using Dominio;
using Dominio.Interfaces;

namespace Aplicacao
{
    public class AplicacaoPassageiro:Aplicacao<Passageiro>
    {
        private readonly IContexto<Passageiro> _contexto; 
        public AplicacaoPassageiro(IContexto<Passageiro> repositorio) : base(repositorio)
        {
            _contexto = repositorio;
        }
    }
}
