﻿using System.Collections.Generic;
using System.Linq;
using Dominio;
using Dominio.Interfaces;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Repositorio
{
    public class ContextoAplicacao<T> : IContexto<T> where T : Entidade
    {
        private readonly Contexto<T> _contexto;

        public ContextoAplicacao()
        {
            _contexto = new Contexto<T>();
        }

        public void Salvar(T entidade)
        {
            _contexto.Collection.Save(entidade);
        }

        public void Excluir(string id)
        {
            _contexto.Collection.Remove(Query.EQ("_id", id));
        }

        public IEnumerable<T> ListarTodos()
        {
            return _contexto.Collection.AsQueryable();
        }

        public T ListarPorId(string id)
        {
            return _contexto.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }
    }
}