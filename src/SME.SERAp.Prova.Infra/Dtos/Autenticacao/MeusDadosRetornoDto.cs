﻿using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class MeusDadosRetornoDto : DtoBase
    {
        public long AlunoId { get; set; }
        public string DreAbreviacao { get; set; }
        public string Escola { get; set; }
        public string Turma { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string TipoTurno { get; set; }
        public int TamanhoFonte { get; set; }
        public Modalidade Modalidade { get; set; }
        public int FamiliaFonte { get; set; }
        public int InicioTurno { get; set; }
        public int FimTurno { get; set; }
        public int[] Deficiencias { get; set; }

        public MeusDadosRetornoDto(
            long alunoId,
            string dreAbreviacao, 
            string escola, 
            string turma, 
            string nome, 
            string ano, 
            string tipoTurno, 
            int tamanhoFonte, 
            Modalidade modalidade, 
            int familiaFonte, 
            int inicioTurno, 
            int fimTurno,
            int[] deficiencias)
        {
            AlunoId = alunoId;
            DreAbreviacao = dreAbreviacao;
            Escola = escola;
            Turma = turma;
            Nome = nome;
            Ano = ano;
            TipoTurno = tipoTurno;
            TamanhoFonte = tamanhoFonte;
            Modalidade = modalidade;
            FamiliaFonte = familiaFonte;
            InicioTurno = inicioTurno;
            FimTurno = fimTurno;
            Deficiencias = deficiencias;
        }
    }
}
