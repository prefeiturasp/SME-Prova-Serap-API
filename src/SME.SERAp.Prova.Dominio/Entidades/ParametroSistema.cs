using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ParametroSistema : EntidadeBase
    {
       
        public int? Ano { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public TipoParametroSistema Tipo { get; set; }
        public string Valor { get; set; }

        public ParametroSistema()
        {

        }

        public ParametroSistema(int ano,bool ativo, string descricao, string nome, TipoParametroSistema tipo, string valor)
        {
            Ano = ano;
            Ativo = ativo;
            Descricao = descricao;
            Nome = nome;
            Tipo = tipo;
            Valor = valor;
    }
    }
}