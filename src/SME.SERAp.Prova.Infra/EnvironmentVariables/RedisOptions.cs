using StackExchange.Redis;

namespace SME.SERAp.Prova.Infra.EnvironmentVariables
{
    public class RedisOptions
    {
        public string Endpoint { get; set; }
        public Proxy Proxy { get; set; }
        public int SyncTimeout { get; set; } = 5000;
    }
}
