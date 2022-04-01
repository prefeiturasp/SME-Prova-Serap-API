using MessagePack;

namespace SME.SERAp.Prova.Dominio
{
    [MessagePackObject(keyAsPropertyName: true)]
    public abstract class EntidadeBase
    {
        public long Id { get; set; }
    }
}
