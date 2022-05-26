using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra
{
    public class QuestaoCompletaDto : DtoBase
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public int Tipo { get; set; }
        public int QuantidadeAlternativas { get; set; }
        public IEnumerable<ArquivoDto> Arquivos { get; set; }
        public IEnumerable<ArquivoDto> Audios { get; set; }
        public IEnumerable<ArquivoVideoDto> Videos { get; set; }
        public IEnumerable<AlternativaDto> Alternativas { get; set; }

    }
}
