using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;

namespace Aplicacao
{
    public class AplicacaoUsuario:Aplicacao<Usuario>
    {
        private readonly IContexto<Usuario> _contexto; 
        public AplicacaoUsuario(IContexto<Usuario> repositorio) : base(repositorio)
        {
            _contexto = repositorio;
        }

        public Usuario Logar(string login, string senha)
        {
           return _contexto.ListarTodos().FirstOrDefault(x => x.Login == login && x.Senha == senha);
        }
    }
}
