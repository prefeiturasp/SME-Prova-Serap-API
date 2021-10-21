using MediatR;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirPreferenciasUsuarioCommand : IRequest<bool>
    {
        public IncluirPreferenciasUsuarioCommand(int tamanhoFonte,
            FamiliaFonte familiaFonte, long usuarioId)
        {
            TamanhoFonte = tamanhoFonte;
            FamiliaFonte = familiaFonte;
            UsuarioId = usuarioId;
        }

        public long UsuarioId { get; set; }
        public int TamanhoFonte { get; set; }
        public FamiliaFonte FamiliaFonte { get; set; }
    }
}