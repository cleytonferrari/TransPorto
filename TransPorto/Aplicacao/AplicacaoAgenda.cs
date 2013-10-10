using Dominio;
using Dominio.Interfaces;

namespace Aplicacao
{
    public class AplicacaoAgenda:Aplicacao<Agenda>
    {
        private readonly IContexto<Agenda> _contexto; 
        public AplicacaoAgenda(IContexto<Agenda> repositorio) : base(repositorio)
        {
            _contexto = repositorio;
        }
    }
}
