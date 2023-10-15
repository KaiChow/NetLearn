using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EFCoreNet.API.Config
{
    public class DefaultValueSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema == null)
            {
                return;
            }
            var objSchema = schema;
            foreach (var property in objSchema.Properties)
            {
                if (property.Value.Type == "string" && property.Value.Default == null)
                {
                    property.Value.Default = new OpenApiString("");
                }
            }
        }
    }
}
