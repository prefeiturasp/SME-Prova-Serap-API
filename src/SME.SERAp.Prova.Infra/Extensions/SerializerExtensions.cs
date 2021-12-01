using System.Text.Json;

namespace SME.SERAp.Prova.Infra
{
    public static class JsonSerializerExtensions
    {
        public static T ConverterObjectStringPraObjeto<T>(this string objectString)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(objectString, jsonSerializerOptions);
        }
    }
}