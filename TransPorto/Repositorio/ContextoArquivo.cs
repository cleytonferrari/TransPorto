using System.Collections.Generic;
using System.IO;
using Dominio;
using Dominio.Interfaces;

namespace Repositorio
{
    class ContextoArquivo<T> : IContextoArquivo<T> where T : Entidade
    {
        private readonly Contexto<T> _contexto;

        public ContextoArquivo()
        {
            _contexto = new Contexto<T>();
        }
        public string SalvarArquivo(Stream arquivo, string nome, string contentType)
        {
            return _contexto.InserirArquivo(arquivo, nome, contentType);
        }

        public void ExcluirArquivo(string idArquivo)
        {
            _contexto.ExcluirArquivo(idArquivo);
        }

        public Dictionary<string, string> RetornaArquivo(string id, ref System.IO.MemoryStream retorno)
        {
            return _contexto.BuscarArquivo(id, ref retorno);
        }
    }
}
