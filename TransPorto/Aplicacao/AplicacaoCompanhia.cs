using Dominio;
using Dominio.Interfaces;

namespace Aplicacao
{
    public class AplicacaoCompanhia:Aplicacao<CompanhiasAereas>
    {
        private readonly IContexto<CompanhiasAereas> _contexto; 
        public AplicacaoCompanhia(IContexto<CompanhiasAereas> repositorio) : base(repositorio)
        {
            _contexto = repositorio;
        }
    }
}
