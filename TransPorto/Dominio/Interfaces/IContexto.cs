using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IContexto<T> where T : Entidade
    {
        void Salvar(T entidade);

        void Excluir(string id);

        IEnumerable<T> ListarTodos();

        T ListarPorId(string id);
    }
}
