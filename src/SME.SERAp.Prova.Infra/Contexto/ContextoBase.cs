﻿using SME.SERAp.Prova.Infra.Interfaces;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra.Contexto
{
    public abstract class ContextoBase : IContextoAplicacao
    {
        protected ContextoBase()
        {
            Variaveis = new Dictionary<string, object>();
        }

        public string NomeUsuario => ObterVariavel<string>("NomeUsuario") ?? "Sistema";
        public string UsuarioLogado => ObterVariavel<string>("UsuarioLogado") ?? "Sistema";
        public string PerfilUsuario => ObterVariavel<string>("PerfilUsuario") ?? string.Empty;
        public IDictionary<string, object> Variaveis { get; set; }

        public abstract void AdicionarVariaveis(IDictionary<string, object> variaveis);
        public abstract IContextoAplicacao AtribuirContexto(IContextoAplicacao contexto);

        public T ObterVariavel<T>(string nome)
        {
            object valor = null;

            if (Variaveis.TryGetValue(nome, out valor))
                return (T)valor;

            return default(T);
        }
    }
}