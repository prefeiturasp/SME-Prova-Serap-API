using StackExchange.Redis;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra.EnvironmentVariables
{
    public class RedisOptions
    {
        public List<string> Endpoints { get; set; }
        public Proxy Proxy { get; set; }
        public int SyncTimeout { get; set; } = 5000;
    }
}
