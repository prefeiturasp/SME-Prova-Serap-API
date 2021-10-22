﻿namespace SME.SERAp.Prova.Infra
{
    public class MeusDadosRetornoDto
    {
        public MeusDadosRetornoDto(string nome, string ano, string turno, int tamanhoFonte, int familiaFonte)
        {
            Nome = nome;
            Ano = ano;
            TipoTurno = turno;
            TamanhoFonte = tamanhoFonte;
            FamiliaFonte = familiaFonte;
        }

        public string Nome { get; set; }
        public string Ano { get; set; }
        public string TipoTurno { get; set; }
        public int TamanhoFonte { get; set; }
        public int FamiliaFonte { get; set; }
    }
}
