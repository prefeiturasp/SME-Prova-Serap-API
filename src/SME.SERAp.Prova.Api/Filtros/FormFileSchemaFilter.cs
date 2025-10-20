using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace SME.SERAp.Prova.Api.Filtros
{
    public class FormFileSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(IFormFile))
            {
                schema.Format = "binary";
                schema.Type = "file";
                schema.Description =
                    "Representa um arquivo enviado via multipart/form-data.\n\n" +
                    "Propriedades do arquivo (não aparecem aqui, mas estão disponíveis no backend):\n" +
                    "- ContentType\n" +
                    "- ContentDisposition\n" +
                    "- Headers\n" +
                    "- Length\n" +
                    "- Name\n" +
                    "- FileName";
            }
        }
    }
}