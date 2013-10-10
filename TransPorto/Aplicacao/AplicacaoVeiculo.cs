using Dominio;
using Dominio.Interfaces;

namespace Aplicacao
{
    public class AplicacaoVeiculo:Aplicacao<Veiculo>
    {
        private readonly IContexto<Veiculo> _contexto; 
        public AplicacaoVeiculo(IContexto<Veiculo> repositorio) : base(repositorio)
        {
            _contexto = repositorio;
        }
    }
}
