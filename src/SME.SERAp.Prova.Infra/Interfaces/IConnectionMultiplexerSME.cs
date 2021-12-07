using StackExchange.Redis;

namespace SME.SERAp.Prova.Infra.Interfaces
{
    public interface IConnectionMultiplexerSME
    {
        IDatabase GetDatabase();
    }
}
