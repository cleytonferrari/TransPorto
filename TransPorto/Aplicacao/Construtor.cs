using Dominio;
using Repositorio;

namespace Aplicacao
{
    public static class Construtor<T> where T : Entidade
    {
        public static Aplicacao<T> Aplicacao()
        {
            return new Aplicacao<T>(new ContextoAplicacao<T>());
        }

        public static ContextoArquivo<T> ContextoArquivo()
        {
            return new ContextoArquivo<T>();
        }

        public static AplicacaoUsuario AplicacaoUsuario()
        {
            return new AplicacaoUsuario(new ContextoAplicacao<Usuario>());
        }

        public static AplicacaoMotorista AplicacaoMotorista()
        {
            return new AplicacaoMotorista(new ContextoAplicacao<Motorista>());
        }
        public static AplicacaoVeiculo AplicacaoVeiculo()
        {
            return new AplicacaoVeiculo(new ContextoAplicacao<Veiculo>());
        }
        public static AplicacaoAgenda AplicacaoAgenda()
        {
            return new AplicacaoAgenda(new ContextoAplicacao<Agenda>());
        }
        public static AplicacaoPassageiro AplicacaoPassageiro()
        {
            return new AplicacaoPassageiro(new ContextoAplicacao<Passageiro>());
        }
    }
}
