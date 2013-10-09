using System.Collections.Generic;
using System.IO;

namespace Dominio.Interfaces
{
    public interface IContextoArquivo<T> where T : Entidade
    {
        string SalvarArquivo(Stream arquivo, string nome, string contentType);

        void ExcluirArquivo(string idArquivo);

        Dictionary<string, string> RetornaArquivo(string id, ref MemoryStream retorno);
    }
}
