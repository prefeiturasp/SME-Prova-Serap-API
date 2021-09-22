namespace SME.SERAp.Prova.Dominio
{
    public class Arquivo : EntidadeBase
    {
        public Arquivo()
        {

        }
        public Arquivo(string caminho, long tamanhoBytes, long legadoId)
        {
            Caminho = caminho;
            TamanhoBytes = tamanhoBytes;
            LegadoId = legadoId;
        }

        public string Caminho { get; set; }
        public long TamanhoBytes { get; set; }
        public long LegadoId { get; set; }

        public string CaminhoParaEnunciado()
        {
            return $"#{LegadoId}#";
        }
    }
}
