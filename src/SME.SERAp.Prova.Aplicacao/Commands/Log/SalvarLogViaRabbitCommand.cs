using MediatR;
using Newtonsoft.Json.Converters;
using SME.SERAp.Prova.Dominio;
using System.Text.Json.Serialization;

namespace SME.SERAp.Prova.Aplicacao
{
   public class SalvarLogViaRabbitCommand : IRequest<bool>
    {
        public SalvarLogViaRabbitCommand(string mensagem, LogNivel nivel, string observacao = "", string projeto = "Serap-Estudantes-API", string rastreamento = "", string excecaoInterna = "")
        {
            Mensagem = mensagem;
            Nivel = nivel;
            Observacao = observacao;
            Projeto = projeto;
            Rastreamento = rastreamento;
            ExcecaoInterna = excecaoInterna;
        }

        public string Mensagem { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LogNivel Nivel { get; set; }
        public string Observacao { get; set; }
        public string Projeto { get; set; }
        public string Rastreamento { get; set; }
        public string ExcecaoInterna { get; }
    }
}
