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
    }
}
