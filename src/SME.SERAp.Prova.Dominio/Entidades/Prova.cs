﻿using System;

namespace SME.SERAp.Prova.Dominio
{
    public class Prova : EntidadeBase
    {
        public Prova()
        {
            Inclusao = DateTime.Now;
        }
        public Prova(long id, string descricao,DateTime? inicioDownload, DateTime inicio, DateTime fim, int totalItens, long legadoId, string senha, bool possuiBIB)
        {
            Id = id;
            Descricao = descricao;
            Inicio = inicio;
            InicioDownload = inicioDownload;
            Fim = fim;
            TotalItens = totalItens;
            LegadoId = legadoId;
            Senha = senha;
            Inclusao = DateTime.Now;
            PossuiBIB = possuiBIB;
        }

        public string Descricao { get; set; }
        public DateTime? InicioDownload { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int TempoExecucao { get; set; }
        public DateTime Inclusao { get; set; }
        public int TotalItens { get; set; }
        public int TotalCadernos { get; set; }
        public string Disciplina { get; set; }
        public long LegadoId { get; set; }
        public string Senha { get; set; }
        public bool PossuiBIB { get; set; }
        public Modalidade Modalidade { get; set; }
        public long? DisciplinaId { get; set; }
        public bool FormatoTai { get; set; }
        public ProvaFormatoTaiItem? ProvaFormatoTaiItem { get; set; }
    }
}